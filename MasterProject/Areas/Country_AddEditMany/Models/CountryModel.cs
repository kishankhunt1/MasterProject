namespace MasterProject.Areas.Country_AddEditMany.Models
{
    public class CountryModel
    {
        public bool IsSelected { get; set; }
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
