namespace MVC.ViewModels.CatalogViewModels;

using MVC.ViewModels.Pagination;

public class IndexViewModel
{
    public IEnumerable<CatalogItem> CatalogItems { get; set; } = null!;
    public IEnumerable<SelectListItem> Categories { get; set; } = null!;
    public IEnumerable<SelectListItem> Mechanics { get; set; } = null!;
    public IEnumerable<SelectListItem> Sort { get; set; } = null!;
    public int? CategoryFilterApplied { get; set; }
    public int? MechanicFilterApplied { get; set; }
    public int? SortApplied { get; set; }
    public PaginationInfo PaginationInfo { get; set; } = null!;
}