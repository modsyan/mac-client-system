using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using MacClientSystem.Application.Common.Models.DTOs.Identity;
using MacClientSystem.Infrastructure.Identity.DTOs;
using MacClientSystem.Infrastructure.Services;
using MacClientSystem.Infrastructure.Services.MacSys.OnlineApi.Models;
using MacClientSystem.Infrastructure.MacOfflineAPI.Models;
namespace MacClientSystem.Infrastructure.MacOfflineAPI;

    public interface MacOffAPI
    {
        

        [Post("/auth")]
        Task<IApiResponse<JwtToken>> Login(AuthCommand loginDto);
        [Post("user")]
        Task<IApiResponse<Guid?>> Register(CreateUserCommand applicationUserDto);
        [Get("user/profile")]
        Task<IApiResponse<ProfileVm>> GetProfile();
    }   
