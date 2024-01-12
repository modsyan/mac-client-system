namespace MacClientSystem.Domain.Entities;

public class Coupon
{
    public string Code { get; set; } = string.Empty!;
    public int Discount { get; set; }
    public int Id { get; set; }
    public int IsActive { get; set; }

}
