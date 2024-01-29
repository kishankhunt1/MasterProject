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
        public IActionResult Add(int? ImageID)
        {
            var model = new ImageModel();
            if (ImageID != null)
            {
                model = bal.PR_Image_SelectByPK(Convert.ToInt32(ImageID));
                return View("ImageAddEdit", model);
            }
            return View("ImageAddEdit", model);
        }
        #endregion

        #region Save Record
        [HttpPost]
        public IActionResult Save(ImageModel modelImage)
        {


            if (modelImage.ImageID == null)
            {
                string uniqueFileName = UploadImage(modelImage);
                var data = new ImageModel()
                {
                    ImageBrand = modelImage.ImageBrand,
                    ImageDescription = modelImage.ImageDescription,
                    Path = uniqueFileName
                };

                if ((bool)bal.PR_Image_Insert(data))
                {
                    TempData["success"] = "Image inserted successfully.";
                }
            }
            else
            {
                var data = bal.PR_Image_SelectByPK(Convert.ToInt32(modelImage.ImageID));
                string uniqueFileName = string.Empty;
                if (modelImage.ImagePath != null)
                {
                    if (data.Path != null)
                    {
                        string filepath = Path.Combine(environment.WebRootPath, "Content/Images", data.Path);
                        if (System.IO.File.Exists(filepath))
                        {
                            System.IO.File.Delete(filepath);
                        }
                        uniqueFileName = UploadImage(modelImage);
                    }
                }

                data.ImageBrand = modelImage.ImageBrand;
                data.ImageDescription = modelImage.ImageDescription;
                if (modelImage.ImagePath != null)
                {
                    data.Path = uniqueFileName;
                }

                if ((bool)bal.PR_Image_UpdateByPK(data))
                {
                    TempData["success"] = "Record updated successfully.";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Upload Image on Folder
        private string UploadImage(ImageModel modelImage)
        {
            string uniqueFileName = string.Empty;
            if (modelImage.ImagePath != null)
            {
                string uploadFolder = Path.Combine(environment.WebRootPath, "Content/Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + modelImage.ImagePath.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    modelImage.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        #endregion

        #region Delete Record
        public IActionResult Delete(int ImageID)
        {

            var data = bal.PR_Image_SelectByPK(ImageID);
            if (data != null)
            {
                string deleteFromFolder = Path.Combine(environment.WebRootPath, "Content/Images/");
                string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, data.Path);
                if (currentImage != null)
                {
                    if (System.IO.File.Exists(currentImage))
                    {
                        System.IO.File.Delete(currentImage);
                    }
                }
            }

            if ((bool)bal.PR_Image_DeleteByPK(ImageID))
            {
                TempData["success"] = "Record deleted successfully";
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}
