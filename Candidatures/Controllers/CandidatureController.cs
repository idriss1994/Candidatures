using Candidatures.Models;
using Candidatures.Repository;
using Candidatures.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Candidatures.Controllers
{
    public class CandidatureController : Controller
    {
        private readonly ICandidatureRepository _candidatureRepository;

        public CandidatureController(ICandidatureRepository candidatureRepository)
        {
            _candidatureRepository = candidatureRepository;
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
                var candidature = new Candidature
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    LevelOfStudy = model.LevelOfStudy,
                    NumberOfYearsOfExperience = model.NumberOfYearsOfExperience,
                    LastEmployer = model.LastEmployer
                };

                await _candidatureRepository.AddCandidatureAsync(candidature);
            }
            return View(model);
        }
    }
}
