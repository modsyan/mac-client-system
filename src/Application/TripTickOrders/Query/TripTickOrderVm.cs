using Microsoft.Extensions.DependencyInjection.TripTickOrders.Query;

namespace MacClientSystem.Application.TripTickOrders.Query;

public class TripTickOrderVm
{
    public IList<TripTickOrderDto> TripTickOrders { get; set; } = new List<TripTickOrderDto>();
}
