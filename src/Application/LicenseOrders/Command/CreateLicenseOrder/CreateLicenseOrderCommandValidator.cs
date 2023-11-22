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
        
        RuleFor(v => v.NationalityId)
            .NotEmpty();
        
        RuleFor(v => v.SourceOfLocalLicenseId)
            .NotEmpty();
        
        RuleFor(v => v.Gander)
            .NotEmpty();
        
        RuleFor(v => v.PassportId)
            .MaximumLength(100)
            .NotEmpty();
        
        RuleFor(v => v.LicenseTypeId)
            .NotEmpty();
        
        RuleFor(v => v.LicenseDuration)
            .NotEmpty();
        
        RuleFor(v => v.PersonalPhotoFileId)
            .NotEmpty();
        
        RuleFor(v => v.PersonalPhoto)
            .NotEmpty();
        
        RuleFor(v => v.LocalDrivingLicense)
            .NotEmpty();
        
        RuleFor(v => v.Passport)
            .NotEmpty();
    }
}
