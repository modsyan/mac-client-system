#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models.DTOs.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MacClientSystem.Web.Endpoints;

public class Authentication : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapPost(Login)
            .MapPost(Register);
    }

    public async Task<ActionResult<LoginResponseDto>> Login(IIdentityService identityService, [FromBody] LoginDto login)
    {
        return await identityService.AuthenticateAsync(login.Username, login.Password);
    }

    public async Task<bool> Register(IIdentityService identityService, [FromBody] RegisterUserCommand cmd)
    {
        return await identityService.RegisterUserAsync(cmd);
    }
}
