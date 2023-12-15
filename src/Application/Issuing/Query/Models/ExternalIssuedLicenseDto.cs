namespace MacClientSystem.Application.Issuing.Query.Models;

public class ExternalIssuedLicenseDto
{
    public Guid LicenseId { get; set; } 
    public string Name { get; set; } = string.Empty;
    public DateTime Issued { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public string LicenseImagePath { get; set; } = string.Empty;
}
