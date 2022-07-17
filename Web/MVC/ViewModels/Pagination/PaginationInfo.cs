namespace MVC.ViewModels.Pagination;

public class PaginationInfo
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int ActualPage { get; set; }
    public int TotalPages { get; set; }
    public int? CategoryFilter { get; set; }
    public int? MechanicFilter { get; set; }
    public int? Sort { get; set; }
    public string Previous { get; set; }
    public string Next { get; set; }
}