using System.Drawing;

namespace MacClientSystem.Domain.Entities;

public class TripTickOrder : BaseAuditableEntity
{
    
    #region User

    // FIXME: TILL REMOVE FIREBASE AUTHENTICATION
    public string ExternalUserId { get; set; } = string.Empty!;
    public int AccountId { get; set; }

    public Account Account { get; set; } = null!;

    public string FullName { get; set; } = String.Empty;

    #endregion

    #region Order Status

    public bool IsPaid { get; set; } = false;
    public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

    #endregion

    #region temp

    // public int ResidenceCountryId { get; set; }
    // public Country ResidenceCountry { get; set; } = new();
    public string ResidenceCountry { get; set; } = string.Empty!;
    

    #endregion


    #region temp

    // public int NationalityId { get; set; }
    // public Country Nationality { get; set; } = new();
    public string NationalityCountry { get; set; } = string.Empty!;

    #endregion

    public string GovernmentalId { get; set; } = String.Empty;

    public string PassportId { get; set; } = String.Empty;

    public string Address1 { get; set; } = String.Empty;
    public string Address2 { get; set; } = String.Empty;

    public string PhoneNumber1 { get; set; } = string.Empty;
    public string PhoneNumber2 { get; set; } = string.Empty;

    public ExtraDriversCount ExtraDriversCount { get; set; } = ExtraDriversCount.None;

    #region temp

    // public int VehicleRegistrationCountryId { get; set; }
    // public Country VehicleRegistrationCountry { get; set; } = new();
    public string VehicleRegistrationCountry { get; set; } = string.Empty!;

    #endregion


    public string VehicleNumber { get; set; } = String.Empty;

    public VehicleLicenseType VehicleLicenseType { get; set; }

    public DateTime VehicleLicenseExpiryDate { get; set; }


    public string VehicleBrand { get; set; } = String.Empty;
    public string VehicleModel { get; set; } = String.Empty;

    public int VehicleTypeId { get; set; }
    public VehicleType VehicleType { get; set; } = null!;

    public int VehiclePassengersCount { get; set; }

    public DateTime VehicleManufactureDate { get; set; }

    public float VehicleWeight { get; set; }

    public int SlenderType { get; set; } //TODO: MIGRATE TO DATABASE

    public int HorsePower { get; set; }

    // public Color VehicleColor { get; set; }
    public string VehicleColor { get; set; } = string.Empty;

    public UpholsteryType UpholsteryType { get; set; }

    public string VehicleEngineId { get; set; } = string.Empty;

    public string VehicleCoverId { get; set; } = string.Empty; // Chaseh

    public bool AirConditionerAvailable { get; set; } = false;

    public bool RadioAvailable { get; set; } = false;

    public int SpareTiresNumber { get; set; } = 0;

    public string Equipment { get; set; } = string.Empty;

    public string Plugins { get; set; } = string.Empty;

    public decimal VehiclePrice { get; set; }

    public CurrencyType CurrencyType { get; set; }

    public Guid VehicleRegistrationCopyDocumentId { get; set; }
    public UploadedFile VehicleRegistrationCopyDocument { get; set; } = null!;

    public Guid PassportDocumentId { get; set; }
    public UploadedFile PassportDocument { get; set; } = null!;

    public Guid PersonalGovernmentalIdentityDocumentId { get; set; }
    public UploadedFile PersonalGovernmentalIdentityDocument { get; set; } = null!;
}
