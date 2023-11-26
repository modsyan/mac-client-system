using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.LicenseOrders.Query;

public static class LicenseOrderMapping
{
    public static LicenseOrderDto MapToDto(this LicenseOrder licenseOrder)
    {
        return new LicenseOrderDto
        {
            Id = licenseOrder.Id,
            ExternalUserId = licenseOrder.ExternalUserId,
            AccountId= licenseOrder.AccountId,
            FullName = licenseOrder.FullName,
            BirthDate = licenseOrder.BirthDate,
            BloodType = licenseOrder.BloodType,
            NationalityCountry = licenseOrder.NationalityCountry,
            SourceOfLocalLicenseCountry = licenseOrder.SourceOfLocalLicenseCountry,
            Gander = licenseOrder.Gander,
            PassportTextId = licenseOrder.PassportTextId,
            LicenseType = licenseOrder.LicenseType,
            LicenseDuration = licenseOrder.LicenseDuration,
            PersonalPhotoUrl = FileHelper.GetFilePath(licenseOrder.PersonalPhoto),
            LocalDrivingLicense = FileHelper.GetFilePath(licenseOrder.LocalDrivingLicense),
            PassportImage = FileHelper.GetFilePath(licenseOrder.PassportImage),
        };
    }
}
