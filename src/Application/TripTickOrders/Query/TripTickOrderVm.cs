using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.TripTickOrders.Query;

public class TripTickOrderVm
{
    public IList<TripTickOrderDto> TripTickOrders { get; set; } = new List<TripTickOrderDto>();
    // public IList<TripTickOrder> TripTickOrders { get; set; } = new List<TripTickOrder>();
}
