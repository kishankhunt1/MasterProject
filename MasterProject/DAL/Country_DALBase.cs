using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

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

        //PR_Country_SelectAllWithPagination
    }
}
