namespace MacClientSystem.Domain.Entities;

public class City: BaseEntity
{
    public string Title { get; set; } = string.Empty!;
    public int CountryId { get; set; }
    public virtual Country Country { get; set; } = default!;
}
