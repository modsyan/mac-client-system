namespace MacClientSystem.Infrastructure.Identity.Models;

public class JwtOptions
{
    public const string JwtOptionsSectionName = "Jwt";
    public string Key { get; set; } = string.Empty;
    public double DurationsInDays { get; set; }
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}
