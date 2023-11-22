using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.LicenseOrders.Query;

public class LicenseOrderDto: IMapFrom<LicenseOrder>
{
    // public int Id { get; set; }
    // public string ApplicationUserId { get; set; }
    // public string LicenseCategory { get; set; }
    // public int LicenseCategoryId { get; set; }
    // public string LicenseNumber { get; set; }
    // public DateTime LicenseExpiryDate { get; set; }
    // public string LicenseImage { get; set; }
    public void Mapping(Profile profile)
    {
        // profile.CreateMap<LicenseOrder, LicenseOrderDto>()
        //     .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
        //     .ForMember(d => d.ApplicationUserId, opt => opt.MapFrom(s => s.ApplicationUserId))
        //     .ForMember(d => d.LicenseCategory, opt => opt.MapFrom(s => s.LicenseCategory))
        //     .ForMember(d => d.LicenseCategoryId, opt => opt.MapFrom(s => s.LicenseCategoryId))
        //     .ForMember(d => d.LicenseNumber, opt => opt.MapFrom(s => s.LicenseNumber))
        //     .ForMember(d => d.LicenseExpiryDate, opt => opt.MapFrom(s => s.LicenseExpiryDate))
        //     .ForMember(d => d.LicenseImage, opt => opt.MapFrom(s => s.LicenseImage))
    }
}
