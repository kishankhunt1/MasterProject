using Microsoft.AspNetCore.Mvc;

namespace MasterProject.Areas.Image.Controllers
{
    [Area("Image")]
    [Route("[Controller]/[action]")]
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View("ImageList");
        }
    }
}
