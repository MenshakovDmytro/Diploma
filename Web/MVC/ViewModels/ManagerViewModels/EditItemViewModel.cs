namespace MVC.ViewModels.ManagerViewModels;

public class EditItemViewModel
{
    public CatalogItem CatalogItem { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
    public IEnumerable<SelectListItem> Mechanics { get; set; }
    public int CategoryId { get; set; }
    public int MechanicId { get; set; }
}