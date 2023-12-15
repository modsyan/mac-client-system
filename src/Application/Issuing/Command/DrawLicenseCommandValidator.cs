using MacClientSystem.Application.Common.Interfaces;

namespace MacClientSystem.Application.Issuing.Command;

public class DrawLicenseCommandValidator : AbstractValidator<DrawLicenseCommand>
{
    public DrawLicenseCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(v=>v.Id).MustAsync(
            async (id, cancellationToken) => await context.ExternalIssuedLicenses
                .AnyAsync(x => x.LicenseOrderId != id, cancellationToken)
            ).WithMessage("License is already issued.");
        // RuleFor(v => v.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        // RuleFor(v => v.Id).LessThan(1000000000).WithMessage("Id must be less than 1000000000.");
        // RuleFor(v => v.Id).MustAsync(Exist).WithMessage("Id does not exist.");
        // RuleFor(v => v.Id).MustAsync(NotIssued).WithMessage("License is already issued.");
        // RuleFor(v => v.Id).MustAsync(NotExpired).WithMessage("License is expired.");
        // RuleFor(v => v.Id).MustAsync(NotRevoked).WithMessage("License is revoked.");
        // RuleFor(v => v.Id).MustAsync(NotSuspended).WithMessage("License is suspended.");
        // RuleFor(v => v.Id).MustAsync(NotLost).WithMessage("License is lost.");
        // RuleFor(v => v.Id).MustAsync(NotStolen).WithMessage("License is stolen.");
        // RuleFor(v => v.Id).MustAsync(NotDestroyed).WithMessage("License is destroyed.");
        // RuleFor(v => v.Id).MustAsync(NotDamaged).WithMessage("License is damaged.");
        // RuleFor(v => v.Id).MustAsync(NotDefaced).WithMessage("License is defaced.");
        // RuleFor(v => v.Id).MustAsync(NotAltered).WithMessage("License is altered.");
        // RuleFor(v => v.Id).MustAsync(NotMutilated).WithMessage("License is mutilated.");
        // RuleFor(v => v.Id).MustAsync(NotImpaired).WithMessage("License is impaired.");
        // RuleFor(v => v.Id).MustAsync(NotInvalid).WithMessage("License is invalid.");
        // RuleFor(v => v.Id).MustAsync(NotInUse).WithMessage("License is in use.");
        // RuleFor(v => v.Id).MustAsync(NotInPossession).WithMessage("License is in possession.");
        // RuleFor(v => v.Id).MustAsync(NotInCustody).WithMessage("License is in custody.");
        // RuleFor(v => v.Id).MustAsync(NotInControl).WithMessage("License is in control.");
        // RuleFor(v => v.Id).MustAsync(NotInPossessionOfAnother).WithMessage("License is in possession of another.");

    }
}
