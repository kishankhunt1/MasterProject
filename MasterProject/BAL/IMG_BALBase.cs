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
        public List<ImageModel> PR_Image_SelectAll()
        {
            DataTable dt = dal.PR_Image_SelectAll();
            List<ImageModel> list = new List<ImageModel>();
            foreach(DataRow dr in dt.Rows)
            {
                ImageModel model = new ImageModel();
                model.ImageID = Convert.ToInt32(dr["ImageID"].ToString());
                model.ImageBrand = dr["ImageBrand"].ToString();
                model.ImageDescription= dr["ImageDescription"].ToString();
                model.Path = dr["Path"].ToString();
                list.Add(model);
            }
            return list;
        }
        #endregion

        #region PR_Image_Insert
        public bool? PR_Image_Insert(ImageModel modelImage)
        {
            try
            {
                return dal.PR_Image_Insert(modelImage);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Image_UpdateByPK
        public bool? PR_Image_UpdateByPK(ImageModel modelImage)
        {
            try
            {
                return dal.PR_Image_UpdateByPK(modelImage);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Image_DeleteByPK
        public bool? PR_Image_DeleteByPK(int ImageID)
        {
            try
            {
                return dal.PR_Image_DeleteByPK(ImageID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Image_SelectByPK
        public ImageModel PR_Image_SelectByPK(int ImageID)
        {
            DataTable dt = dal.PR_Image_SelectByPK(ImageID);
            ImageModel model = new ImageModel();
            foreach (DataRow dr in dt.Rows)
            {
                model.ImageID = Convert.ToInt32(dr["ImageID"]);
                model.ImageBrand = dr["ImageBrand"].ToString();
                model.ImageDescription = dr["ImageDescription"].ToString();
                model.Path = dr["Path"].ToString();
            }
            return model;
        }
        #endregion
    }
}
