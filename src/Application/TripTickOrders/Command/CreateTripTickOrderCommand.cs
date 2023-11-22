using System.Drawing;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Domain.Enums;

namespace MacClientSystem.Application.TripTickOrders.Command;

public class CreateTripTickOrderCommand: IRequest<bool>
{
    public string FullName { get; set; } = String.Empty;
    public int ResidenceCountryId { get; set; }
    public int NationalityId { get; set; }
    public string GovernmentalId { get; set; } = String.Empty;
    public string PassportId { get; set; } = String.Empty;
    public string Address1 { get; set; } = String.Empty;
    public string Address2 { get; set; } = String.Empty;
    public string PhoneNumber1 { get; set; } = string.Empty;
    public string PhoneNumber2 { get; set; } = string.Empty;
    public ExtraDriversCount ExtraDriversCount { get; set; } = ExtraDriversCount.None;
    public int VehicleRegistrationCountryId { get; set; }
    public string VehicleNumber { get; set; } = String.Empty;
    public VehicleLicenseType VehicleLicenseType { get; set; }
    public DateTime VehicleLicenseExpiryDate { get; set; }
    public string VehicleBrand { get; set; } = String.Empty;
    public string VehicleModel { get; set; } = String.Empty;
    public int VehicleTypeId { get; set; }
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
public class CreateTripTickOrderCommandHandler: IRequestHandler<CreateTripTickOrderCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateTripTickOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateTripTickOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TripTickOrder>(request);
        
        var tripTick = await  _context.TripTickOrders.AddAsync(entity, cancellationToken);
        
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
