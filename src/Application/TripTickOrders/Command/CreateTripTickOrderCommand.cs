using System.Drawing;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace MacClientSystem.Application.TripTickOrders.Command;

public class CreateTripTickOrderCommand : IRequest<bool>
{
   
 
    // FIXME: TILL REMOVE FIREBASE AUTHENTICATION
    public string ExternalUserId { get; set; } = string.Empty!;
    public string FullName { get; set; } = String.Empty;
    public string ResidenceCountry { get; set; } = string.Empty!;
    public string NationalityCountry { get; set; } = string.Empty!;
    public string GovernmentalId { get; set; } = String.Empty;
    public string PassportId { get; set; } = String.Empty;
    public string Address1 { get; set; } = String.Empty;
    public string Address2 { get; set; } = String.Empty;
    public string PhoneNumber1 { get; set; } = string.Empty;
    public string PhoneNumber2 { get; set; } = string.Empty;
    public ExtraDriversCount ExtraDriversCount { get; set; } = ExtraDriversCount.None;
    public string VehicleRegistrationCountry { get; set; } = string.Empty!;
    public string VehicleNumber { get; set; } = String.Empty;
    public VehicleLicenseType VehicleLicenseType { get; set; }
    public DateTime VehicleLicenseExpiryDate { get; set; }
    public string VehicleBrand { get; set; } = String.Empty;
    public string VehicleModel { get; set; } = String.Empty;
    public int VehicleTypeId { get; set; }
    public int VehiclePassengersCount { get; set; }
    public DateTime VehicleManufactureDate { get; set; }
    public float VehicleWeight { get; set; }
    public int SlenderType { get; set; } //TODO: MIGRATE TO DATABASE
    public int HorsePower { get; set; }
    public string VehicleColor { get; set; } = string.Empty!;
    public UpholsteryType UpholsteryType { get; set; }
    public string VehicleEngineId { get; set; } = string.Empty;
    public string VehicleCoverId { get; set; } = string.Empty; // Chaseh
    public bool AirConditionerAvailable { get; set; } = false;
    public bool RadioAvailable { get; set; } = false;
    public int SpareTiresNumber { get; set; } = 0;
    public string Equipment { get; set; } = string.Empty; // mo2edat
    public string Plugins { get; set; } = string.Empty; // 2edafat
    public decimal VehiclePrice { get; set; }
    public CurrencyType CurrencyType { get; set; }

    public IFormFile VehicleRegistrationCopyDocument { get; set; } = null!;
    public IFormFile PassportDocument { get; set; } = null!;
    public IFormFile PersonalGovernmentalIdentityDocument { get; set; } = null!;
}

public class CreateTripTickOrderCommandHandler
    (IApplicationDbContext context, IFileUploadService fileUploadService/*, IUser user*/) : IRequestHandler<CreateTripTickOrderCommand,
        bool>
{
    public async Task<bool> Handle(CreateTripTickOrderCommand request, CancellationToken cancellationToken)
    {
        var vehicleRegistrationCopyDocument =
            await fileUploadService.SaveToDisk(request.VehicleRegistrationCopyDocument);
        var passportDocument = await fileUploadService.SaveToDisk(request.PassportDocument);
        var personalGovernmentalIdentityDocument =
            await fileUploadService.SaveToDisk(request.PersonalGovernmentalIdentityDocument);

        var order = new TripTickOrder
        {
            // AccountId = user.AccountId, //TODO: HANDLE CLAIMS AND CURRENT USER SERVICE || HANDLE JwtFactoryService
            AccountId = 1, 
            ExternalUserId = request.ExternalUserId,
            FullName = request.FullName,
            ResidenceCountry = request.ResidenceCountry,
            NationalityCountry = request.NationalityCountry,
            GovernmentalId = request.GovernmentalId,
            PassportId = request.PassportId,
            Address1 = request.Address1,
            Address2 = request.Address2,
            PhoneNumber1 = request.PhoneNumber1,
            PhoneNumber2 = request.PhoneNumber2,
            ExtraDriversCount = request.ExtraDriversCount,
            VehicleRegistrationCountry = request.VehicleRegistrationCountry,
            VehicleNumber = request.VehicleNumber,
            VehicleLicenseType = request.VehicleLicenseType,
            VehicleLicenseExpiryDate = request.VehicleLicenseExpiryDate,
            VehicleBrand = request.VehicleBrand,
            VehicleModel = request.VehicleModel,
            VehicleTypeId = request.VehicleTypeId,
            VehiclePassengersCount = request.VehiclePassengersCount,
            VehicleManufactureDate = request.VehicleManufactureDate,
            VehicleWeight = request.VehicleWeight,
            SlenderType = request.SlenderType,
            HorsePower = request.HorsePower,
            VehicleColor = request.VehicleColor,
            UpholsteryType = request.UpholsteryType,
            VehicleEngineId = request.VehicleEngineId,
            VehicleCoverId = request.VehicleCoverId,
            AirConditionerAvailable = request.AirConditionerAvailable,
            RadioAvailable = request.RadioAvailable,
            SpareTiresNumber = request.SpareTiresNumber,
            Equipment = request.Equipment,
            Plugins = request.Plugins,
            VehiclePrice = request.VehiclePrice,
            CurrencyType = request.CurrencyType,
            VehicleRegistrationCopyDocument = vehicleRegistrationCopyDocument,
            PassportDocument = passportDocument,
            PersonalGovernmentalIdentityDocument = personalGovernmentalIdentityDocument,
        };

        var tripTick = await context.TripTickOrders.AddAsync(order, cancellationToken);

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
