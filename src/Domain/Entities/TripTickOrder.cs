using System.Drawing;

namespace MacClientSystem.Domain.Entities;

public class TripTickOrder
{
    public Guid ApplicationUserId { get; set; }
    
    public string FullName { get; set; } = String.Empty;
    
    public int ResidenceCountryId { get; set; }
    public Country ResidenceCountry { get; set; } = new();
    
    public int NationalityId { get; set; }
    public Country Nationality { get; set; } = new();
    
    public string GovernmentalId { get; set; } = String.Empty;
    
    public string PassportId { get; set; } = String.Empty;
    
    public string Address1 { get; set; } = String.Empty;
    public string Address2 { get; set; } = String.Empty;
    
    public string PhoneNumber1 { get; set; } = string.Empty;
    public string PhoneNumber2 { get; set; } = string.Empty;
    
    public ExtraDriversCount ExtraDriversCount { get; set; } = ExtraDriversCount.None;
    
    public int VehicleRegistrationCountryId { get; set; }
    public Country VehicleRegistrationCountry { get; set; } = new();
    
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
    
    // public SelenderType SelenderType { get; set; }
    
    public int HorsePower { get; set; }
    
    public Color VehicleColor { get; set; }
    
    // public TangedType TangedType { get; set; } leazer or 2oma4 

    public string VehicleEngineId { get; set; } = string.Empty;

    public string VehicleCoverId { get; set; } = string.Empty; // Chaseh

    public bool AirCondetionarAvailable { get; set; } = false;

    public bool RadioAvailable { get; set; } = false;
    
    // public GuntesStepnsNumber StepnsNumber { get; set; }

    public string Extensions { get; set; } = string.Empty; // mo2edat
    public string Plugins { get; set; } = string.Empty; // 2edafat
    
    public decimal VehiclePrice { get; set; }
    public CurrencyType CurrencyType { get; set; }

    public Guid VehicleRegistrationCopyDocumentId { get; set; }
    public UploadedFile VehicleRegistrationCopyDocument { get; set; } = null!;
    
    public Guid PassportDocumentId { get; set; }
    public UploadedFile PassportDocument { get; set; } = null!;
    
    public Guid PersonalGovernmentalIdentityId { get; set; }
    public UploadedFile PersonalGovernmentalIdentity { get; set; } = null!;
}
