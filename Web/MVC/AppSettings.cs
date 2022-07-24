namespace MVC;

public class AppSettings
{
    public string CatalogUrl { get; set; } = null!;
    public string BasketUrl { get; set; } = null!;
    public string MarketingUrl { get; set; } = null!;
    public string CatalogItemUrl { get; set; } = null!;
    public string CatalogCategoryUrl { get; set; } = null!;
    public string CatalogMechanicUrl { get; set; } = null!;
    public int SessionCookieLifetimeMinutes { get; set; }
    public string CallBackUrl { get; set; } = null!;
    public string IdentityUrl { get; set; } = null!;
}