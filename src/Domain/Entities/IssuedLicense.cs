namespace MacClientSystem.Domain.Entities;

public class IssuedLicense: BaseAuditableEntity
{
    public int LicenseOrderId { get; set; }
    public LicenseOrder LicenseOrder { get; set; } = null!;
    
    public Guid UploadedFileId { get; set; }
    public UploadedFile UploadedFile { get; set; } = null!;
}
