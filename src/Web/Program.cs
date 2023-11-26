using MacClientSystem.Application;
using MacClientSystem.Infrastructure;
using MacClientSystem.Infrastructure.Data;
using MacClientSystem.Infrastructure.Identity.Models;
using MacClientSystem.Web;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();
builder.Services.AddCors();
// builder.Services.AddAntiforgery(options =>
// {
//     options.Cookie.Expiration = TimeSpan.Zero;
// });
builder.Services.AddAntiforgery(options =>
{
     options.Cookie.Name = "XSRF-TOKEN";
     options.FormFieldName = "X-XSRF-TOKEN";
});

// builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.JwtOptionsSectionName));
// builder.Services.Configure<DiskFileOptions>(builder.Configuration.GetSection(DiskFileOptions.DiskFileOptionSectionName));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseSwaggerUi3(settings =>
{
    // settings.Path = "/api";
    // settings.DocumentPath = "/api/specification.json";
});


// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller}/{action=Index}/{id?}");


// app.MapRazorPages();

// app.MapFallbackToFile("index.html");

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var ex = context.Features.Get<IExceptionHandlerFeature>();
        if (ex != null)
        {
            var err = JsonConvert.SerializeObject(new { error = ex.Error.Message });
            await context.Response.WriteAsync(err).ConfigureAwait(false);
        }
    });
});

app.Map("/", () => Results.Redirect("/api"));


app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.MapEndpoints();


app.Run();

public partial class Program
{
}
