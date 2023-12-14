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
            .MapGet(GetIssuedLicense, "licenses/{id}");
        
        // /api/issuing/licenses/user/{userId}
        // /api/issuing/licenses/{id}

    }
    
    public async Task<IssuedLicenseVm> GetAllUserIssuedLicense(ISender sender, [AsParameters] GetUserIssuedLicensesQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<IssuedLicenseDto> GetIssuedLicense(ISender sender, [AsParameters] GetIssuedLicenseByOrderIdQuery query)
    {
       return await sender.Send(query);
    }

    public async Task<bool> DrawLicense(ISender sender, [FromBody] DrawLicenseCommand command)
    {
        return await sender.Send(command);
    }
}
