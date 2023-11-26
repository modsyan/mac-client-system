using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace MacClientSystem.Application.LicenseOrders.Command.CreateLicenseOrder;

public class CreateLicenseOrderCommand : IRequest<bool>
{
    // FIXME: TILL REMOVE FIREBASE AUTHENTICATION
    public string ExternalUserId { get; set; } = string.Empty!;
    public string FullName { get; set; } = string.Empty!;
    public DateTime BirthDate { get; set; }
    public BloodTypes BloodType { get; set; }
    public string NationalityCountry { get; set; } = default!;
    public string SourceOfLocalLicenseCountry { get; set; } = string.Empty!;
    public Gander Gander { get; set; }
    public string PassportTextId { get; set; } = String.Empty!;
    public List<LicenseType> LicenseType { get; set; } = null!;
    public int LicenseDuration { get; set; }
    public IFormFile PersonalPhoto { get; set; } = default!;
    public IFormFile LocalDrivingLicense { get; set; } = default!;
    public IFormFile Passport { get; set; } = default!;
    // public IFormFileCollection Attachments { get; set; } = default!;
    // public List<IFormFile> Attachments { get; set; } = default!;
}

public class CreateLicenseOrderCommandHandler
    (IApplicationDbContext context, IFileUploadService fileUploadService, IUser user) : IRequestHandler<CreateLicenseOrderCommand, bool>
{
    public IUser User { get; } = user;

    public async Task<bool> Handle(CreateLicenseOrderCommand request, CancellationToken cancellationToken)
    {
        // var personalPhoto = await fileUploadService.SaveToDisk(request.Attachments[0]);
        // var localDrivingLicense = await fileUploadService.SaveToDisk(request.Attachments[1]);
        // var passportImage = await fileUploadService.SaveToDisk(request.Attachments[2]);
            
        var personalPhoto = await fileUploadService.SaveToDisk(request.PersonalPhoto);
        var localDrivingLicense = await fileUploadService.SaveToDisk(request.LocalDrivingLicense);
        var passportImage = await fileUploadService.SaveToDisk(request.Passport);
        
        var order = new LicenseOrder
        {
            // AccountId = user.AccountId,
            AccountId = 1,
            ExternalUserId = request.ExternalUserId,
            Gander = request.Gander,
            LicenseType = request.LicenseType,
            BirthDate = request.BirthDate,
            FullName = request.FullName,
            BloodType = request.BloodType,
            NationalityCountry = request.NationalityCountry,
            SourceOfLocalLicenseCountry = request.SourceOfLocalLicenseCountry,
            PassportTextId = request.PassportTextId,
            LicenseDuration = request.LicenseDuration,
            PersonalPhoto = personalPhoto,
            LocalDrivingLicense = localDrivingLicense,
            PassportImage = passportImage,
        };
        
        await context.LicenseOrders.AddAsync(order, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
