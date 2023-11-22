using MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;
using MacClientSystem.Application.LicenseOrders.Query;
using MacClientSystem.Application.TripTickOrders.Command;
using MacClientSystem.Application.TripTickOrders.Query;
using Microsoft.Extensions.DependencyInjection.TripTickOrders.Query;

namespace MacClientSystem.Web.Endpoints;

public class Order: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetLicenseOrder)
            .MapGet(GetLicenseOrderList)
            .MapPost(CreateLicenseOrder)
            .MapGet(GetTripTickOrder)
            .MapGet(GetTripTickOrderList)
            .MapPost(CreateTripTickOrder);

    }
    
    private static async Task<LicenseOrderVm> GetLicenseOrderList(ISender sender)
    {
        return await sender.Send(new GetLicenseOrderListQuery());
    }
    
    private static async Task<LicenseOrderDto> GetLicenseOrder(ISender sender, GetLicenseOrderQuery query)
    {
        return await sender.Send(query);
    }
    
    private static async Task<bool> CreateLicenseOrder(ISender sender, CreateLicenseOrderCommand command)
    {
        return await sender.Send(command);
    }

    private static async Task<TripTickOrderVm> GetTripTickOrderList(ISender sender)
    {
        return await sender.Send(new GetTripTickOrderListQuery());
    }
    
    private static async Task<TripTickOrderDto> GetTripTickOrder(ISender sender, GetTripTickOrderQuery query)
    {
        return await sender.Send(query);
    }
    
    private static async Task<bool> CreateTripTickOrder(ISender sender, CreateTripTickOrderCommand command)
    {
        return await sender.Send(command);
    }

    
}
