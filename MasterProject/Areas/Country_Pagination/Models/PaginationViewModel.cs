namespace MasterProject.Areas.Country_Pagination.Models
{
    public class PaginationViewModel
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<Country> Countries { get; set; }
    }
}
