using System.Diagnostics.CodeAnalysis;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Constants;
using MacClientSystem.Infrastructure.Data;
using MacClientSystem.Infrastructure.Data.Interceptors;
using MacClientSystem.Infrastructure.Files;
using MacClientSystem.Infrastructure.Identity;
using MacClientSystem.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MacClientSystem.Infrastructure;

public static class DependencyInjection
{
    [RequiresUnreferencedCode("JsonSerializer")]
    [RequiresDynamicCode("JsonSerializer")]
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
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

        
        
        return services;
    }
}
