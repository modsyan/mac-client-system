using MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;
using MacClientSystem.Application.LicenseOrders.Query;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Namotion.Reflection;

namespace MacClientSystem.Web.Endpoints;

public class License : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            // .RequireAuthorization()
            .AllowAnonymous()
            .MapPost(CreateLicenseOrder)
            .MapGet(GetALlLicenseOrder)
            .MapGet(GetLicenseOrder, "{id}")
            .MapGet(GetExternalUserLicenseOrder, "external/{externalUserId}")
            ;
    }

    public async Task<LicenseOrderVm> GetALlLicenseOrder(ISender sender)
    {
        return await sender.Send(new GetAllLicenseOrderQuery());
    }

    public async Task<LicenseOrderDto> GetLicenseOrder(ISender sender, [AsParameters] GetLicenseOrderByIdQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<LicenseOrderVm> GetExternalUserLicenseOrder(ISender sender,
        [AsParameters] GetUserLicenseOrderQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<bool> CreateLicenseOrder(ISender sender, [FromForm] CreateLicenseOrderCommand command)
    {
        // await antiforgery.ValidateRequestAsync(HttpContext);
        // await antiforgery.ValidateNullability();
        return await sender.Send(command);
    }
}
