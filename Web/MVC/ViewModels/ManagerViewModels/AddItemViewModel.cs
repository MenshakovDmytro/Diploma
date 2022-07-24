namespace MVC.ViewModels.ManagerViewModels;

public class AddItemViewModel
{
    public IEnumerable<SelectListItem> Categories { get; set; } = null!;
    public IEnumerable<SelectListItem> Mechanics { get; set; } = null!;
    public int CategoryId { get; set; }
    public int MechanicId { get; set; }
}