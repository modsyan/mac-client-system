using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Domain.Enums;

namespace MacClientSystem.Application.TripTickOrders.Query;

public class TripTickOrderDto : IMapFrom<TripTickOrder>
{
    // FIXME: TILL REMOVE FIREBASE AUTHENTICATION
    public int Id { get; set; }
    public string ExternalUserId { get; set; } = string.Empty!;

    public int AccountId { get; set; }

    public string FullName { get; set; } = String.Empty;

    public bool IsPaid { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public string ResidenceCountry { get; set; } = string.Empty!;

    public string NationalityCountry { get; set; } = string.Empty!;

    public string GovernmentalId { get; set; } = string.Empty;

    public string PassportId { get; set; } = string.Empty;

    public string Address1 { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;

    public string PhoneNumber1 { get; set; } = string.Empty;
    public string PhoneNumber2 { get; set; } = string.Empty;

    public ExtraDriversCount ExtraDriversCount { get; set; }

    public string VehicleRegistrationCountry { get; set; } = string.Empty!;

    public string VehicleNumber { get; set; } = String.Empty;

    public VehicleLicenseType VehicleLicenseType { get; set; }

    public DateTime VehicleLicenseExpiryDate { get; set; }

    public string VehicleBrand { get; set; } = String.Empty;

    public string VehicleModel { get; set; } = String.Empty;

    public string VehicleType { get; set; } = null!;

    public int VehiclePassengersCount { get; set; }

    public DateTime VehicleManufactureDate { get; set; }

    public float VehicleWeight { get; set; }

    public int SlenderType { get; set; }

    public int HorsePower { get; set; }

    public string VehicleColor { get; set; } = string.Empty;

    public UpholsteryType UpholsteryType { get; set; }

    public string VehicleEngineId { get; set; } = string.Empty;

    public string VehicleCoverId { get; set; } = string.Empty;

    public bool AirConditionerAvailable { get; set; }

    public bool RadioAvailable { get; set; }

    public int SpareTiresNumber { get; set; }

    public string Equipment { get; set; } = string.Empty;

    public string Plugins { get; set; } = string.Empty;

    public decimal VehiclePrice { get; set; }

    public CurrencyType CurrencyType { get; set; }

    public string VehicleRegistrationCopyDocument { get; set; } = null!;

    public string PassportDocument { get; set; } = null!;

    public string PersonalGovernmentalIdentityDocument { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TripTickOrder, TripTickOrderDto>()
            // .ForMember(d => d.ExternalUserId, opt => opt.MapFrom(s => s.ExternalUserId))
            // .ForMember(d => d.AccountId, opt => opt.MapFrom(s => s.AccountId))
            // .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.FullName))
            // .ForMember(d => d.IsPaid, opt => opt.MapFrom(s => s.IsPaid))
            // .ForMember(d => d.OrderStatus, opt => opt.MapFrom(s => s.OrderStatus))
            // .ForMember(d => d.ResidenceCountry, opt => opt.MapFrom(s => s.ResidenceCountry))
            // .ForMember(d => d.NationalityCountry, opt => opt.MapFrom(s => s.NationalityCountry))
            // .ForMember(d => d.GovernmentalId, opt => opt.MapFrom(s => s.GovernmentalId))
            // .ForMember(d => d.PassportId, opt => opt.MapFrom(s => s.PassportId))
            // .ForMember(d => d.Address1, opt => opt.MapFrom(s => s.Address1))
            // .ForMember(d => d.Address2, opt => opt.MapFrom(s => s.Address2))
            // .ForMember(d => d.PhoneNumber1, opt => opt.MapFrom(s => s.PhoneNumber1))
            // .ForMember(d => d.PhoneNumber2, opt => opt.MapFrom(s => s.PhoneNumber2))
            // .ForMember(d => d.ExtraDriversCount, opt => opt.MapFrom(s => s.ExtraDriversCount))
            // .ForMember(d => d.VehicleRegistrationCountry, opt => opt.MapFrom(s => s.VehicleRegistrationCountry))
            // .ForMember(d => d.VehicleNumber, opt => opt.MapFrom(s => s.VehicleNumber))
            // .ForMember(d => d.VehicleLicenseType, opt => opt.MapFrom(s => s.VehicleLicenseType))
            // .ForMember(d => d.VehicleLicenseExpiryDate, opt => opt.MapFrom(s => s.VehicleLicenseExpiryDate))
            // .ForMember(d => d.VehicleBrand, opt => opt.MapFrom(s => s.VehicleBrand))
            // .ForMember(d => d.VehicleModel, opt => opt.MapFrom(s => s.VehicleModel))
            
            
            .ForMember(d => d.VehicleType, opt => opt.MapFrom(s => s.VehicleType.Name))
            
            // .ForMember(d => d.VehiclePassengersCount, opt => opt.MapFrom(s => s.VehiclePassengersCount))
            // .ForMember(d => d.VehicleManufactureDate, opt => opt.MapFrom(s => s.VehicleManufactureDate))
            // .ForMember(d => d.VehicleWeight, opt => opt.MapFrom(s => s.VehicleWeight))
            // .ForMember(d=>d.SlenderType,opt=>opt.MapFrom(s=>s.SlenderType))
            // .ForMember(d => d.HorsePower, opt => opt.MapFrom(s => s.HorsePower))
            // .ForMember(d => d.VehicleColor, opt => opt.MapFrom(s => s.VehicleColor))
            // .ForMember(d => d.UpholsteryType, opt => opt.MapFrom(s => s.UpholsteryType))
            // .ForMember(d => d.VehicleEngineId, opt => opt.MapFrom(s => s.VehicleEngineId))
            // .ForMember(d => d.VehicleCoverId, opt => opt.MapFrom(s => s.VehicleCoverId))
            // .ForMember(d => d.AirConditionerAvailable, opt => opt.MapFrom(s => s.AirConditionerAvailable))
            // .ForMember(d => d.RadioAvailable, opt => opt.MapFrom(s => s.RadioAvailable))
            // .ForMember(d => d.SpareTiresNumber, opt => opt.MapFrom(s => s.SpareTiresNumber))
            // .ForMember(d => d.Equipment, opt => opt.MapFrom(s => s.Equipment))
            // .ForMember(d => d.Plugins, opt => opt.MapFrom(s => s.Plugins))
            // .ForMember(d => d.VehiclePrice, opt => opt.MapFrom(s => s.VehiclePrice))
            // .ForMember(d => d.CurrencyType, opt => opt.MapFrom(s => s.CurrencyType))
            
            
            // .ForMember(d => d.VehicleRegistrationCopyDocument, opt => opt.MapFrom(s => FileHelper.GetFromDisk(s.VehicleRegistrationCopyDocument)))
            // .ForMember(d => d.PassportDocument, opt => opt.MapFrom(s => FileHelper.GetFromDisk(s.PassportDocument)))
            // .ForMember(d => d.PersonalGovernmentalIdentityDocument, opt => opt.MapFrom(s => FileHelper.GetFromDisk(s.PersonalGovernmentalIdentityDocument)));
            
            .ForMember(d => d.VehicleRegistrationCopyDocument, opt => opt.MapFrom(s => FileHelper.GetFilePath(s.VehicleRegistrationCopyDocument)))
            .ForMember(d => d.PassportDocument, opt => opt.MapFrom(s => FileHelper.GetFilePath(s.PassportDocument)))
            .ForMember(d => d.PersonalGovernmentalIdentityDocument, opt => opt.MapFrom(s => FileHelper.GetFilePath(s.PersonalGovernmentalIdentityDocument)));
            ;
    }
}
