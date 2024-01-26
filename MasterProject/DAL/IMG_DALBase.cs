using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MasterProject.Areas.Image.Models;

namespace MasterProject.DAL
{
    public class IMG_DALBase:DAL_Helper
    {
        #region Image Region

        #region Method: PR_Image_SelectAll
        public DataTable PR_Image_SelectAll()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Image_SelectAll");

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_Image_SelectByPK
        public DataTable PR_Image_SelectByPK(int? ImageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Image_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "@ImageID", SqlDbType.Int, ImageID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_Image_Insert
        public bool? PR_Image_Insert(ImageModel modelImage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Image_Insert");
                sqlDB.AddInParameter(dbCMD, "@ImageBrand", SqlDbType.NVarChar, modelImage.ImageBrand);
                sqlDB.AddInParameter(dbCMD, "@ImageDescription", SqlDbType.NVarChar, modelImage.ImageDescription);
                sqlDB.AddInParameter(dbCMD, "@Path", SqlDbType.NVarChar, modelImage.Path);


                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_Image_UpdateByPK
        public bool? PR_Image_UpdateByPK(ImageModel modelImage)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Image_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "@ImageID", SqlDbType.Int, modelImage.ImageID);
                sqlDB.AddInParameter(dbCMD, "@ImageBrand", SqlDbType.NVarChar, modelImage.ImageBrand);
                sqlDB.AddInParameter(dbCMD, "@ImageDescription", SqlDbType.NVarChar, modelImage.ImageDescription);
                sqlDB.AddInParameter(dbCMD, "@Path", SqlDbType.NVarChar, modelImage.Path);

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_Image_DeleteByPK
        public bool? PR_Image_DeleteByPK(int ImageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Image_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "@ImageID", SqlDbType.Int, ImageID);


                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #endregion
    }
}
