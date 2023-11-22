namespace MacClientSystem.Domain.Entities;

public class LicenseOrder: BaseAuditableEntity
{
    public Guid ApplicationUserId { get; set; }
    // public virtual ApplicationUser ApplicationUser { get; set; } = default!;
    
    public string FullName { get; set; } = string.Empty!;
    
    public DateTime BirthDate { get; set; }
    
    public BloodTypes BloodType { get; set; }
    
    public int NationalityId { get; set; }
    public virtual Country  Nationality { get; set; } = default!;
    
    public int SourceOfLocalLicenseId { get; set; }
    public virtual Country SourceOfLocalLicense { get; set; } = default!;
    
    public Gander Gander { get; set; }
    
    public string PassportId { get; set; } = String.Empty!;
    
    public int LicenseTypeId { get; set; }

    public LicenseCategory LicenseType { get; set; } = null!;
    
    // public LicenseDuration LicenseDuration { get; set; }
    public int LicenseDuration { get; set; }
    
    public int PersonalPhotoFileId { get; set; }
    public UploadedFile PersonalPhoto { get; set; } = default!;
    
    public int LocalDrivingLicenseFileId { get; set; }
    public UploadedFile LocalDrivingLicense { get; set; } = default!;
    
    public int PassportFileId { get; set; }
    public UploadedFile Passport { get; set; } = default!;
}
