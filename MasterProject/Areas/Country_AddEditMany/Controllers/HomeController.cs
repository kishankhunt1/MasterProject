using MasterProject.Areas.Country_AddEditMany.Models;
using MasterProject.BAL;
using Microsoft.AspNetCore.Mvc;

namespace MasterProject.Areas.Country_AddEditMany.Controllers
{
    [Area("Country_AddEditMany")]
    [Route("[Controller]/[action]")]
    public class HomeController : Controller
    {
        Country_BAL bal = new Country_BAL();
        public IActionResult Index()
        {
            ViewBag.CountryList = bal.SelectAllCountry();
            return View("CountryList");
        }

        public IActionResult AddMany()
        {
            // Initialize a list of CountryAddEditModel (assumed model for Add/Edit page)
            List<CountryModel> addManyList = new List<CountryModel>();

            // Add 10 rows to the list initially
            for (int i = 0; i < 10; i++)
            {
                addManyList.Add(new CountryModel());
            }

            return View("AddMany", addManyList);
        }

        //[HttpPost]
        //public IActionResult AddMany(List<CountryModel> model)
        //{
        //    // Filter out unchecked rows
        //    var selectedRows = model.Where(row => row.IsSelected).ToList();

        //    foreach (var countryModel in selectedRows)
        //    {
        //        if ((bool)bal.PR_Country_Insert(countryModel))
        //        {
        //            TempData["success"] = "Country inserted successfully.";
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult AddMany(List<CountryModel> model)
        {
            // Filter out unchecked rows
            var selectedRows = model.Where(row => row.IsSelected).ToList();

            // Check if any selected row has at least one field filled in
            if (selectedRows.Any(row => !string.IsNullOrEmpty(row.CountryName) || !string.IsNullOrEmpty(row.CountryCode)))
            {
                foreach (var countryModel in selectedRows)
                {
                    // Check if the row has data before attempting to insert
                    if (!string.IsNullOrEmpty(countryModel.CountryName) || !string.IsNullOrEmpty(countryModel.CountryCode))
                    {
                        if ((bool)bal.PR_Country_Insert(countryModel))
                        {
                            TempData["success"] = "Country inserted successfully.";
                        }
                    }
                }
            }
            else
            {
                TempData["warning"] = "No data entered. Please fill in at least one field in the selected rows.";
            }

            return RedirectToAction("Index");
        }



    }
}
