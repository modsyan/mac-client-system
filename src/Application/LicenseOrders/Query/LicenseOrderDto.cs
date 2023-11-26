using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Domain.Enums;

namespace MacClientSystem.Application.LicenseOrders.Query;

public class LicenseOrderDto : IMapFrom<LicenseOrder>
{
    // public string LicenseCategory { get; set; } = string.Empty!;
    // public int LicenseCategoryId { get; set; }
    // public string LicenseNumber { get; set; } = string.Empty!;
    // public DateTime LicenseExpiryDate { get; set; }
    // public string LicenseImage { get; set; } = string.Empty!;


    public string ExternalUserId { get; set; } = string.Empty!;

    public int Id { get; set; }

    // public string ApplicationUserId { get; set; } = string.Empty!;
    public int AccountId { get; set; }
    public string FullName { get; set; } = string.Empty!;
    public DateTime BirthDate { get; set; }
    public BloodTypes BloodType { get; set; }
    public string NationalityCountry { get; set; } = default!;
    public string SourceOfLocalLicenseCountry { get; set; } = string.Empty!;
    public Gander Gander { get; set; }
    public string PassportTextId { get; set; } = String.Empty!;
    public IList<LicenseType> LicenseType { get; set; } = null!;
    public int LicenseDuration { get; set; }
    public string PersonalPhotoUrl { get; set; } = default!;
    public string LocalDrivingLicense { get; set; } = default!;
    public string PassportImage { get; set; } = default!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LicenseOrder, LicenseOrderDto>()
            // .ForMember(d => d.ApplicationUserId, opt => opt.MapFrom(s => s.ApplicationUserId))
            // .ForMember(d => d.LicenseCategory, opt => opt.MapFrom(s => s.LicenseCategory))
            // .ForMember(d => d.LicenseCategoryId, opt => opt.MapFrom(s => s.LicenseCategoryId))
            // .ForMember(d => d.LicenseNumber, opt => opt.MapFrom(s => s.LicenseNumber))
            // .ForMember(d => d.LicenseExpiryDate, opt => opt.MapFrom(s => s.LicenseExpiryDate))
            // .ForMember(d => d.LicenseImage, opt => opt.MapFrom(s => s.LicenseImage));
            .ForMember(d => d.ExternalUserId, opt => opt.MapFrom(s => s.ExternalUserId))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FullName))
            .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => s.BirthDate))
            .ForMember(d => d.BloodType, opt => opt.MapFrom(s => s.BloodType))
            .ForMember(d => d.NationalityCountry, opt => opt.MapFrom(s => s.NationalityCountry))
            .ForMember(d => d.SourceOfLocalLicenseCountry, opt => opt.MapFrom(s => s.SourceOfLocalLicenseCountry))
            .ForMember(d => d.Gander, opt => opt.MapFrom(s => s.Gander))
            .ForMember(d => d.PassportTextId, opt => opt.MapFrom(s => s.PassportTextId))
            .ForMember(d => d.LicenseType, opt => opt.MapFrom(s => s.LicenseType))
            .ForMember(d => d.LicenseDuration, opt => opt.MapFrom(s => s.LicenseDuration))

            // .ForMember(d => d.PersonalPhotoUrl, opt => opt.MapFrom(s => FileHelper.GetFromDisk(s.PersonalPhoto)))
            // .ForMember(d => d.LocalDrivingLicense, opt => opt.MapFrom(s => FileHelper.GetFromDisk(s.LocalDrivingLicense)))
            // .ForMember(d => d.PassportImage, opt => opt.MapFrom(s => FileHelper.GetFromDisk(s.PassportImage)))
            ;
    }
}
