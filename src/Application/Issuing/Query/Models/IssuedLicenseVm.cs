namespace MacClientSystem.Application.Issuing.Query.Models;

public class IssuedLicenseVm
{
    public List<IssuedLicenseDto> List { get; set; } = new List<IssuedLicenseDto>();
    public int RecordsCount { get; set; }
}
