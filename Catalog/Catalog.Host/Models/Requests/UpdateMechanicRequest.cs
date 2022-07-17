namespace Catalog.Host.Models.Requests;

public class UpdateMechanicRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}