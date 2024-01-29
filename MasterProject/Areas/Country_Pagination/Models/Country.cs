namespace MasterProject.Areas.Country_Pagination.Models
{
    public class Country
    {
        public int? CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
