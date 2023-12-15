namespace MacClientSystem.Domain.Entities;


// TODO: To be aware what licenses is issued in this api
public class ExternalIssuedLicense: BaseAuditableEntity
{
    public Guid LicenseOrderId { get; set; }
    public Int64 Serial { get; set; }
    public string Name { get; set; } = string.Empty!;
    public DateTime Issued { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public Guid LicenseImagePathId { get; set; }
    public UploadedFile LicenseImagePath { get; set; } = null!;
}
