using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models.DTOs.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MacClientSystem.Web.Endpoints;

public class Authentication(IIdentityService identityService) : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapPost(Login)
            .MapPost(Register);
    }

    private async Task<ActionResult<LoginResponseDto>> Login(ISender sender, LoginDto login)
    {
        return await identityService.AuthenticateAsync(login.Username, login.Password);
    }

    private async Task<bool> Register(RegisterUserCommand cmd)
    {
        return await identityService.RegisterUserAsync(cmd);
    }
}
