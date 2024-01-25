using MasterProject.Areas.Image.Models;
using MasterProject.BAL;
using Microsoft.AspNetCore.Mvc;

namespace MasterProject.Areas.Image.Controllers
{
    [Area("Image")]
    [Route("[Controller]/[action]")]
    public class ImageController : Controller
    {

        #region Global Declaration
        IMG_BAL bal = new IMG_BAL();
        #endregion

        public IActionResult Index(ImageModel modelImage)
        {
            ViewBag.ImageList = bal.PR_Image_SelectAll(modelImage).ToList();
            return View("ImageList");
        }
        public IActionResult Add()
        {
            return View("ImageAddEdit");
        }
    }
}
