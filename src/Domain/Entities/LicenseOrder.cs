namespace MacClientSystem.Domain.Entities;

public class LicenseOrder: BaseAuditableEntity
{
    
    #region User
    
    public string ExternalUserId { get; set; } = string.Empty!;
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public string FullName { get; set; } = string.Empty!;
    
    #endregion
    
    
    public DateTime BirthDate { get; set; }
    
    public bool IsPaid { get; set; }
    
    public BloodTypes BloodType { get; set; }
    public LicenseStatus LicenseStatus { get; set; } = LicenseStatus.pending;
    #region temp

    // public int NationalityId { get; set; }
    // public virtual Country  Nationality { get; set; } = default!;
    public string NationalityCountry { get; set; } = default!;

    #endregion

    
    #region temp
    // public int SourceOfLocalLicenseId { get; set; }
    // public virtual Country SourceOfLocalLicense { get; set; } = default!;
    public string SourceOfLocalLicenseCountry { get; set; } = string.Empty!;

    #endregion
    
    
    
    public Gander Gander { get; set; }
    
    public string PassportTextId { get; set; } = String.Empty!;
    
    // public int LicenseTypeId { get; set; }

    // public LicenseCategory LicenseType { get; set; } = null!;
    public IList<LicenseType> LicenseType { get; set; } = null!;
    
    // public LicenseDuration LicenseDuration { get; set; }
    public int LicenseDuration { get; set; }
    
    public Guid PersonalPhotoId { get; set; }
    public UploadedFile PersonalPhoto { get; set; } = default!;
    
    public Guid LocalDrivingLicenseId { get; set; }
    public UploadedFile LocalDrivingLicense { get; set; } = default!;
    
    public Guid PassportImageId { get; set; }
    public UploadedFile PassportImage { get; set; } = default!;
}
