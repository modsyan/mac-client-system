using MacClientSystem.Application.TripTickOrders.Command;
using MacClientSystem.Application.TripTickOrders.Query;
using MacClientSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MacClientSystem.Web.Endpoints;

public class TripTick: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
    // FIXME: TILL REMOVE FIREBASE AUTHENTICATION
            .AllowAnonymous()
            .MapGet(GetTripTickOrder, "{id}")
            .MapGet(GetTripTickOrderList)
            .MapGet(GetExternalUserTripTickOrder, "external/{externalUserId}")
            .MapPost(CreateTripTickOrder);
    }
    
    public async Task<TripTickOrderVm> GetTripTickOrderList(ISender sender)
    {
        return await sender.Send(new GetAllTripTickOrderQuery());
    }

    // public async Task<TripTickOrderDto> GetTripTickOrder(ISender sender,
    public async Task<TripTickOrderDto> GetTripTickOrder(ISender sender,
        [AsParameters] GetTripTickOrderByIdQuery byIdQuery)
    {
        return await sender.Send(byIdQuery);
    }
    
    public async Task<TripTickOrderVm> GetExternalUserTripTickOrder(ISender sender,
        [AsParameters] GetUserTripTickOrderQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<bool> CreateTripTickOrder(ISender sender, [FromForm] CreateTripTickOrderCommand command)
    {
        return await sender.Send(command);
    }
}
