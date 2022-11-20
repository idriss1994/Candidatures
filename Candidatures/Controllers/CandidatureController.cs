using Candidatures.Models;
using Candidatures.Repository;
using Candidatures.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Candidatures.Controllers
{
    public class CandidatureController : Controller
    {
        private readonly ICandidatureRepository _candidatureRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidatureController(ICandidatureRepository candidatureRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _candidatureRepository = candidatureRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IEnumerable<Candidature> model = await _candidatureRepository.GetAllCandidaturesAsync();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Search(string term)
        {
            IEnumerable<Candidature> model = await _candidatureRepository.SearchAsync(term);

            return View("List", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _candidatureRepository.DeleteCandidatureAsync(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var candidature = await _candidatureRepository.FindCandidatureByIdAsync(id);
            if (candidature == null)
            {
                return NotFound();
            }
            var model = new CandidatureDetailsViewModel
            {
                Candidature = candidature
            };

            return View(model);
        }

        [HttpGet("candidature")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("candidature")]
        public async Task<IActionResult> Create(CandidatureViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CVFile != null)
                {
                    string fileName = model.CVFile.FileName;
                    string folderCVsPath = Path.Combine(_webHostEnvironment.WebRootPath, "CVs");
                    if (!Directory.Exists(folderCVsPath))
                    {
                        Directory.CreateDirectory(folderCVsPath);
                    }

                    string userFullName = $"{model.FirstName} {model.LastName}";
                    string folderPathCandidature = Path.Combine(_webHostEnvironment.WebRootPath, folderCVsPath, userFullName);

                    if (!Directory.Exists(folderPathCandidature))
                    {
                        Directory.CreateDirectory(folderPathCandidature);
                    }

                    string cvFullPath = Path.Combine(_webHostEnvironment.WebRootPath, folderPathCandidature, fileName);
                    await model.CVFile.CopyToAsync(new FileStream(cvFullPath, FileMode.Create));

                    var candidature = new Candidature
                    {
                        Id = Guid.NewGuid(),
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        LevelOfStudy = model.LevelOfStudy,
                        NumberOfYearsOfExperience = model.NumberOfYearsOfExperience,
                        LastEmployer = model.LastEmployer,
                        CVUrl = Path.Combine("CVs", userFullName, fileName)
                    };

                    await _candidatureRepository.AddCandidatureAsync(candidature);

                    return RedirectToAction("Details", new { candidature.Id });
                }


            }
            return View(model);
        }
    }
}
