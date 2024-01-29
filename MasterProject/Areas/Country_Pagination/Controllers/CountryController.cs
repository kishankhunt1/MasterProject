using MasterProject.Areas.Country_Pagination.Models;
using MasterProject.BAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace MasterProject.Areas.Country_Pagination.Controllers
{
    [Area("Country_Pagination")]
    [Route("[Controller]/[action]")]
    public class CountryController : Controller
    {
        private readonly IConfiguration _configuration;

        public CountryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region Global Decleration
        Country_BAL bal =new Country_BAL();
        #endregion

        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new PaginationViewModel
            {
                Page = page,
                PageSize = pageSize,
                Countries = GetPagedDataFromStoredProcedure(page,pageSize)
            };
            return View("CountryList",model);
        }


        private List<Country> GetPagedDataFromStoredProcedure(int page, int pageSize)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConnectionString")))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("PR_Country_SelectAllWithPagination", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@PageNumber", page);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var countries = new List<Country>();

                        while (reader.Read())
                        {
                            var country = new Country
                            {
                                CountryID = (int)reader["CountryID"],
                                CountryName = reader["CountryName"].ToString(),
                                CountryCode = reader["CountryCode"].ToString(),
                                Created = (DateTime)reader["Created"],
                                Modified = (DateTime)reader["Modified"]
                            };

                            countries.Add(country);
                        }

                        return countries;
                    }
                }
            }
        }
    }
}
