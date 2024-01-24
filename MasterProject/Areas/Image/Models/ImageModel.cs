using System.ComponentModel.DataAnnotations.Schema;

namespace MasterProject.Areas.Image.Models
{
    public class ImageModel
    {
        public int ImageID { get; set; }
        public string ImageBrand { get; set; }
        public string ImageDescription { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile ImagePath { get; set; }
    }
}
