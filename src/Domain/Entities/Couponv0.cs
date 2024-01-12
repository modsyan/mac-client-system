namespace MacClientSystem.Domain.Entities;

public class Couponv0: BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public int Discount { get; set; }
    public bool Status { get; set; }
}
