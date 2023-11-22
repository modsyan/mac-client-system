namespace MacClientSystem.Application.TripTickOrders.Command;

public class CreateTripTickOrderCommandValidator: AbstractValidator<CreateTripTickOrderCommand>
{
    public CreateTripTickOrderCommandValidator()
    {
        RuleFor(v => v.FullName)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.ResidenceCountryId)
            .NotEmpty();
        
        RuleFor(v => v.NationalityId)
            .NotEmpty();
        
        RuleFor(v => v.GovernmentalId)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.PassportId)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.Address1)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.Address2)
            .MaximumLength(100);
        
        RuleFor(v => v.PhoneNumber1)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.PhoneNumber2)
            .MaximumLength(100);
        
        RuleFor(v => v.ExtraDriversCount)
            .NotEmpty();
        
        RuleFor(v => v.VehicleRegistrationCountryId)
            .NotEmpty();
        
        RuleFor(v => v.VehicleNumber)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.VehicleLicenseType)
            .NotEmpty();
        
        RuleFor(v => v.VehicleLicenseExpiryDate)
            .NotEmpty();
        
        RuleFor(v => v.VehicleBrand)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.VehicleModel)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.VehicleTypeId)
            .NotEmpty();
        
        RuleFor(v => v.VehiclePassengersCount)
            .NotEmpty();
        
        RuleFor(v => v.VehicleManufactureDate)
            .NotEmpty();
        
        RuleFor(v => v.VehicleWeight)
            .NotEmpty();
        
        RuleFor(v => v.HorsePower)
            .NotEmpty();
        
        RuleFor(v => v.VehicleColor)
            .NotEmpty();
        
        RuleFor(v => v.VehicleEngineId)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.VehicleCoverId)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.AirCondetionarAvailable)
            .NotEmpty();
        
        RuleFor(v => v.RadioAvailable)
            .NotEmpty();

        RuleFor(v => v.Extensions)
            .MaximumLength(100)
            .NotEmpty();
    }
    
}
