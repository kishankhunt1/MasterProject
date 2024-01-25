using MasterProject.Areas.Image.Models;
using MasterProject.DAL;
using System.Data;

namespace MasterProject.BAL
{
    public class IMG_BALBase
    {

        #region Global Declaration
            IMG_DAL dal = new IMG_DAL();
        #endregion

        #region PR_Image_SelectAll
        public List<ImageModel> PR_Image_SelectAll(ImageModel modelImage)
        {
            DataTable dt = dal.PR_Image_SelectAll();
            List<ImageModel> list = new List<ImageModel>();
            foreach(DataRow dr in dt.Rows)
            {
                ImageModel model = new ImageModel();
                model.ImageID = Convert.ToInt32(dr["ImageID"]);
                model.ImageBrand = dr["ImageBrand"].ToString();
                model.ImageDescription= dr["ImageDescription"].ToString();
                model.Path = dr["Path"].ToString();
                list.Add(model);
            }
            return list;
        }
        #endregion
    }
}
