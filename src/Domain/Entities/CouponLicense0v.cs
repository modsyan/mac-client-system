namespace MacClientSystem.Domain.Entities;

public class CouponLicense: BaseAuditableEntity
{
    public Guid CouponId { get; set; }
    public Couponv0 Couponv0 { get; set; } = null!;
    
    public Guid LicenseId { get; set; }
    public LicenseOrder LicenseOrder { get; set; } = null!;
}
