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

        private readonly IWebHostEnvironment environment;

        public ImageController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }


        #region Select All
        public IActionResult Index()
        {
            ViewBag.ImageList = bal.PR_Image_SelectAll();
            return View("ImageList");
        }
        #endregion

        #region Add or Update Record
        public IActionResult Add()
        {
            return View("ImageAddEdit");
        }
        #endregion

        #region Save Record
        [HttpPost]
        public IActionResult? Save(ImageModel modelImage)
        {
                string uniqueFileName = UploadImage(modelImage);
                var data = new ImageModel()
                {
                    ImageBrand = modelImage.ImageBrand,
                    ImageDescription = modelImage.ImageDescription,
                    Path = uniqueFileName
                };
                if (modelImage.ImageID == 0)
                {
                    if ((bool)bal.PR_Image_Insert(data))
                    {
                        TempData["success"] = "Image inserted successfully.";
                    }
                }
            return RedirectToAction("Index");
        }
        #endregion

        #region Upload Image on Folder
        private string UploadImage(ImageModel modelImage)
        {
            string uniqueFileName=string.Empty;
            if(modelImage.ImagePath != null)
            {
                string uploadFolder =  Path.Combine(environment.WebRootPath,"Content/Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + modelImage.ImagePath.FileName;
                string filePath=Path.Combine(uploadFolder, uniqueFileName);
                using(var fileStream=new FileStream(filePath,FileMode.Create))
                {
                    modelImage.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        #endregion

    }
}
