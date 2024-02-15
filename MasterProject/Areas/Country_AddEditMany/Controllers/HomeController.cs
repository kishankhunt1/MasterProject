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

        [HttpPost]
        public IActionResult AddMany(List<CountryModel> model)
        {
            foreach(var countryModel in model)
            {
                if (countryModel.IsSelected)
                {
                    if ((bool)bal.PR_Country_Insert(countryModel))
                    {
                        TempData["success"] = "Image inserted successfully.";
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
