namespace MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;

public class CreateLicenseOrderCommandValidator: AbstractValidator<CreateLicenseOrderCommand>
{
    public CreateLicenseOrderCommandValidator()
    {
        RuleFor(v => v.FullName)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.BirthDate)
            .NotEmpty();
        
        RuleFor(v => v.BloodType)
            .NotEmpty();
        
        RuleFor(v => v.NationalityCountry)
            .NotEmpty();
        
        RuleFor(v => v.SourceOfLocalLicenseCountry)
            .NotEmpty();
        
        RuleFor(v => v.Gander)
            .NotEmpty();
        
        RuleFor(v => v.PassportTextId)
            .MaximumLength(100)
            .NotEmpty();
        
        // RuleFor(v => v.LicenseTypeId)
        //     .NotEmpty();
        
        RuleFor(v => v.LicenseDuration)
            .NotEmpty();
        
        // RuleFor(v => v.PersonalPhoto)
        //     .NotEmpty();
        //
        // RuleFor(v => v.LocalDrivingLicense)
        //     .NotEmpty();
        //
        // RuleFor(v => v.Passport)
        //     .NotEmpty();
    }
}
