using MasterProject.Areas.Country_AddEditMany.Models;
using MasterProject.Areas.Country_Pagination.Models;
using MasterProject.Areas.Image.Models;
using MasterProject.DAL;
using System.Data;

namespace MasterProject.BAL
{
    public class Country_BALBase
    {
        #region Global Declaration
        Country_DAL dal = new Country_DAL();
        #endregion


        #region Country_Pagination
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
        #endregion

        #region Country_AddEditMany

        #region Method: SelectAllCountry
        public List<CountryModel> SelectAllCountry()
        {
            try
            {
                DataTable dt = dal.SelectAllCountry();
                List<CountryModel> list = new List<CountryModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    CountryModel model = new CountryModel();
                    model.CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                    model.CountryName = dr["CountryName"].ToString();
                    model.CountryCode = dr["CountryCode"].ToString();
                    list.Add(model);
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_Country_Insert
        public bool? PR_Country_Insert(CountryModel modelCountry)
        {
            try
            {
                return dal.PR_Country_Insert(modelCountry);
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
