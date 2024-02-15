using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using MasterProject.Areas.Image.Models;
using MasterProject.Areas.Country_AddEditMany.Models;

namespace MasterProject.DAL
{
    public class Country_DALBase:DAL_Helper
    {

        #region Method: PR_Country_SelectAllWithPagination
        public DataTable PR_Country_SelectAllWithPagination(int page, int pageSize)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Country_SelectAllWithPagination");
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, page);
                sqlDB.AddInParameter(dbCMD, "@PageNumber", SqlDbType.Int, pageSize);

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

        #region Country_AddEditMany

        #region SelectAllCountry
        public DataTable SelectAllCountry()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("SelectAllCountry");
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

        #region InsertCountry
        public bool? PR_Country_Insert(CountryModel modelCountry)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Country_Insert");
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelCountry.CountryName);
                sqlDB.AddInParameter(dbCMD, "CountryCode", SqlDbType.NVarChar, modelCountry.CountryCode);

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
