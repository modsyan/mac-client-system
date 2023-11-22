namespace MacClientSystem.Domain.Entities;

public class Country : BaseAuditableEntity
{
    public string CountryTitles { get; set; } = string.Empty!;
    public string NationalityTitles { get; set; } = string.Empty!;
    public string Abbreviation { get; set; } = string.Empty!;
    public string DialingCode { get; set; } = string.Empty!;
    public ICollection<City> Cities { get; set; } = new List<City>();
}
