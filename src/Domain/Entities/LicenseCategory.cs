namespace MacClientSystem.Domain.Entities;

public class LicenseCategory : BaseAuditableEntity
{
    public string Name = string.Empty!;
    public char Class { get; set; }
    
    public int IconFileId;
    public UploadedFile IconUploadedFile = null!;
}
