using MVC.ViewModels.Pagination;

namespace MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public IEnumerable<CatalogItem> CatalogItems { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
    public IEnumerable<SelectListItem> Mechanics { get; set; }
    public IEnumerable<SelectListItem> Sort { get; set; }
    public int? CategoryFilterApplied { get; set; }
    public int? MechanicFilterApplied { get; set; }
    public int? SortApplied { get; set; }
    public PaginationInfo PaginationInfo { get; set; }
}