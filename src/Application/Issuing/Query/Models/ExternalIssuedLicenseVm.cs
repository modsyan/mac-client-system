namespace MacClientSystem.Application.Issuing.Query.Models;

public class ExternalIssuedLicenseVm
{
    public List<ExternalIssuedLicenseDto> List { get; set; } = new List<ExternalIssuedLicenseDto>();
    public int RecordsCount { get; set; }
}
