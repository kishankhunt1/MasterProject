using Microsoft.AspNetCore.Mvc;

namespace MasterProject.Areas.Country_Pagination.Controllers
{
    [Area("Country_Pagination")]
    [Route("[Controller]/[action]")]
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View("CountryList");
        }
    }
}
