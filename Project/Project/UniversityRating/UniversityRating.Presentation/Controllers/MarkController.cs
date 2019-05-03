using Microsoft.AspNetCore.Mvc;

namespace UniversityRating.Presentation.Controllers
{
    public class MarkController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return
            View();
        }
    }
}