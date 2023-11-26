using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.TripTickOrders.Query;

public static class TripTickOrderMapping
{
    public static TripTickOrderDto MapToDto(this TripTickOrder order)
    {
        return new TripTickOrderDto
        {
            Id = order.Id,
            ExternalUserId = order.ExternalUserId,
            AccountId = order.AccountId,
            FullName = order.FullName,
            IsPaid = order.IsPaid,
            OrderStatus = order.OrderStatus,
            ResidenceCountry = order.ResidenceCountry,
            NationalityCountry = order.NationalityCountry,
            GovernmentalId = order.GovernmentalId,
            PassportId = order.PassportId,
            Address1 = order.Address1,
            Address2 = order.Address2,
            PhoneNumber1 = order.PhoneNumber1,
            PhoneNumber2 = order.PhoneNumber2,
            ExtraDriversCount = order.ExtraDriversCount,
            VehicleRegistrationCountry = order.VehicleRegistrationCountry,
            VehicleNumber = order.VehicleNumber,
            VehicleLicenseType = order.VehicleLicenseType,
            VehicleLicenseExpiryDate = order.VehicleLicenseExpiryDate,
            VehicleBrand = order.VehicleBrand,
            VehicleModel = order.VehicleModel,
            VehicleType = order.VehicleType.Name,
            VehiclePassengersCount = order.VehiclePassengersCount,
            VehicleManufactureDate = order.VehicleManufactureDate,
            VehicleWeight = order.VehicleWeight,
            HorsePower = order.HorsePower,
            VehicleColor = order.VehicleColor,
            UpholsteryType = order.UpholsteryType,
            VehicleEngineId = order.VehicleEngineId,
            VehicleCoverId = order.VehicleCoverId,
            AirConditionerAvailable = order.AirConditionerAvailable,
            RadioAvailable = order.RadioAvailable,
            SpareTiresNumber = order.SpareTiresNumber,
            Equipment = order.Equipment,
            Plugins = order.Plugins,
            VehiclePrice = order.VehiclePrice,
            CurrencyType = order.CurrencyType,
            VehicleRegistrationCopyDocument = FileHelper.GetFilePath(order.VehicleRegistrationCopyDocument),
            PersonalGovernmentalIdentityDocument = FileHelper.GetFilePath(order.PersonalGovernmentalIdentityDocument),
            PassportDocument = FileHelper.GetFilePath(order.PassportDocument),
        };
    }
}
