using MasterProject.Areas.Country_Pagination.Models;
using MasterProject.DAL;
using System.Data;

namespace MasterProject.BAL
{
    public class Country_BALBase
    {
        #region Global Declaration
        Country_DAL dal = new Country_DAL();
        #endregion

        #region PR_Country_SelectAllWithPagination
        public List<Country> PR_Country_SelectAllWithPagination(int page, int pageSize)
        {
            DataTable dt = dal.PR_Country_SelectAllWithPagination(page, pageSize);
            List<Country> list = new List<Country>();

            foreach (DataRow dr in dt.Rows)
            {
                Country model = new Country();
                model.CountryID = Convert.ToInt32(dr["CountryID"]);
                model.CountryName = dr["CountryName"].ToString();
                model.CountryCode = dr["CountryCode"].ToString();
                model.Created = Convert.ToDateTime(dr["Created"]);
                model.Modified = Convert.ToDateTime(dr["Modified"]);
                list.Add(model);
            }
            return list;
        }
        #endregion
    }
}
