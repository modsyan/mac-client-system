using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Options;
using MacClientSystem.Domain.Constants;
using MacClientSystem.Infrastructure.Data;
using MacClientSystem.Infrastructure.Data.Interceptors;
using MacClientSystem.Infrastructure.Files;
using MacClientSystem.Infrastructure.Identity;
using MacClientSystem.Infrastructure.Identity.Models;
using MacClientSystem.Infrastructure.Services;
using MacClientSystem.Infrastructure.Services.MacSys.OnlineApi;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace MacClientSystem.Infrastructure;

public static class DependencyInjection
{
    [RequiresUnreferencedCode("JsonSerializer")]
    [RequiresDynamicCode("JsonSerializer")]
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();


        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JwtOptionsSectionName));
        services.Configure<DiskFileOptions>(configuration.GetSection(DiskFileOptions.DiskFileOptionSectionName));

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddTransient<IFileUploadService, FileUploadService>();


        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        services.Configure<IntegrationOptions.Clients>(
            configuration.GetSection(IntegrationOptions.INTEGRATION_CLIENTS));

        var macSysOptions = configuration.GetSection(IntegrationOptions.MACSYS_ONLINE_API)
            .Get<IntegrationOptions.MacSysOnlineApi>() ?? throw new NullReferenceException();

        services.AddRefitClient<IOnlineApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(macSysOptions.BaseUrl);

                var token = AuthHelpers
                    .GetAccessTokenAsync(
                        string.Format(macSysOptions.TokenEndPoint, macSysOptions.BaseUrl),
                        macSysOptions.ClientId, macSysOptions.Secret).Result;

                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            });


        return services;
    }
}
