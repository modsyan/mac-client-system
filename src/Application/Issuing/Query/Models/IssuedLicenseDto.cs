namespace MacClientSystem.Application.Issuing.Query.Models;

public class IssuedLicenseDto
{
    public Guid Id { get; set; }
    public string LicenseImagePath { get; set; } = string.Empty;
}
