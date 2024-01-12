#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models.DTOs.Identity;
using MacClientSystem.Infrastructure.Identity.DTOs;
using MacClientSystem.Infrastructure.MacOfflineAPI;
using MacClientSystem.Infrastructure.MacOfflineAPI.Models;
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

    public async Task<IActionResult> Login(MacOffAPI offlineAPI, [FromBody] AuthCommand cmd)
    {
       
        var result = await offlineAPI.Login(cmd);

        if (result.Content == null)
            throw new Exception("Invalid username or password");

        return new OkObjectResult(result.Content);
    }

    public async Task<Guid?> Register(MacOffAPI offlineAPI, [FromBody] CreateUserCommand cmd)
    {
       
        var result = await offlineAPI.Register(cmd);

        if (result.Content == null)
            throw new Exception("one or more fields are invalid");

        return result.Content;
    }
    public async Task<ProfileVm> GetProfile(MacOffAPI offlineAPI)
    {
        
        var result = await offlineAPI.GetProfile();

        if (result.Content == null)
            throw new Exception("one or more fields are invalid");

        return result.Content;
    }   
}
