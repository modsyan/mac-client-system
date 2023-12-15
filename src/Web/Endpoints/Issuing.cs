using MacClientSystem.Application.Issuing.Command;
using MacClientSystem.Application.Issuing.Query;
using MacClientSystem.Application.Issuing.Query.Models;
using Microsoft.AspNetCore.Mvc;

namespace MacClientSystem.Web.Endpoints;

public class Issuing : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapPost(DrawLicense, "licenses")
            .MapGet(GetAllUserIssuedLicense, "licenses/user/{userId}")
            .MapGet(GetIssuedLicense, "licenses/{licenseOrderId}");
    }
    
    public async Task<ExternalIssuedLicenseVm> GetAllUserIssuedLicense(ISender sender, [AsParameters] GetUserExternalIssuedLicensesQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<ExternalIssuedLicenseDto> GetIssuedLicense(ISender sender, [AsParameters] GetExternalIssuedLicenseByOrderIdQuery query)
    {
       return await sender.Send(query);
    }

    public async Task<bool> DrawLicense(ISender sender, [FromBody] DrawLicenseCommand command)
    {
        return await sender.Send(command);
    }
}
