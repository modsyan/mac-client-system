#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models.DTOs.Identity;
using MacClientSystem.Infrastructure.Services;
using MacClientSystem.Infrastructure.Services.MacSys.OnlineApi;
using MacClientSystem.Infrastructure.Services.MacSys.OnlineApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

    // public async Task<ActionResult<LoginResponseDto>> Login(IIdentityService identityService, [FromBody] LoginDto login)
    // {
    //     return await identityService.AuthenticateAsync(login.Username, login.Password);
    // }
    //
    // public async Task<bool> Register(IIdentityService identityService, [FromBody] RegisterUserCommand cmd)
    // {
    //     return await identityService.RegisterUserAsync(cmd);
    // }

    public async Task<JwtToken> Login(IOnlineApi onlineApi, [FromBody] AuthCommand cmd)
    {
        // return await identityService.AuthenticateAsync(login.Username, login.Password);
        var result = await onlineApi.Authenticate(cmd);

        if (result.Content == null)
            throw new Exception("Invalid username or password");

        return result.Content;
    }

    public async Task<Guid?> Register(IOnlineApi onlineApi, [FromBody] CreateUserCommand cmd)
    {
        // return await identityService.RegisterUserAsync(cmd);
        var result = await onlineApi.CreateUser(cmd);

        if (result.Content == null)
            throw new Exception("one or more fields are invalid");

        return result.Content;
    }
}
