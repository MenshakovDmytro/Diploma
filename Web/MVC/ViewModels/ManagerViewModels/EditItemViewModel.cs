namespace MVC.ViewModels.ManagerViewModels;

public class EditItemViewModel
{
    public CatalogItem CatalogItem { get; set; } = null!;
    public string PictureFileName { get; set; } = null!;
    public IEnumerable<SelectListItem> Categories { get; set; } = null!;
    public IEnumerable<SelectListItem> Mechanics { get; set; } = null!;
    public int CategoryId { get; set; }
    public int MechanicId { get; set; }
}