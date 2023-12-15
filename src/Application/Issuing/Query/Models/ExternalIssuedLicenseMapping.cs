using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.Issuing.Query.Models;

public static class ExternalIssuedLicenseMapping
{
    public static ExternalIssuedLicenseDto MapToDto(this ExternalIssuedLicense issuedLicense)
    {
        return new ExternalIssuedLicenseDto
        {
            LicenseId = issuedLicense.LicenseOrderId,
            Name = issuedLicense.Name,
            Issued = issuedLicense.Issued,
            ExpiryDate = issuedLicense.ExpiryDate,
            UserId = issuedLicense.UserId,
            AccountId = issuedLicense.AccountId,
            LicenseImagePath = FileHelper.GetFilePath(issuedLicense.LicenseImagePath)
        };
    }
    
}
