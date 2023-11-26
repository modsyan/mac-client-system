namespace MacClientSystem.Domain.Entities;

public class LicenseCategory : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty!;
    // public char Class { get; set; }
    //
    // public Guid IconFileId;
    // public UploadedFile IconUploadedFile = null!;
}
