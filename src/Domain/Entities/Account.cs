namespace MacClientSystem.Domain.Entities;

public class Account: BaseEntity
{
    public string Title { get; set; } = string.Empty;
    
    public ICollection<LicenseOrder> LicenseOrders { get; set; } = new List<LicenseOrder>();
    public ICollection<TripTickOrder> TripTickOrders { get; set; } = new List<TripTickOrder>();
}
