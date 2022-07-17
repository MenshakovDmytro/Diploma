using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Data;

public class BasketItem : IValidatableObject
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureUrl { get; set; } = null!;
    public int Quantity { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (Quantity < 1)
        {
            results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
        }

        return results;
    }
}