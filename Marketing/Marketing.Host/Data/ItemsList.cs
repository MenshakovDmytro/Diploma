namespace Marketing.Host.Data;

public class ItemsList<T>
{
    public long TotalCount { get; set; }
    public IEnumerable<T>? Data { get; init; }
}