using Microsoft.AspNetCore.Mvc;

namespace Candidatures.Controllers
{
    public class CandidatureController : Controller
    {

        [HttpGet("candidature")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
