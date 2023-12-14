#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using System.ComponentModel;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Issuing.Command.Helpers;
using MacClientSystem.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace MacClientSystem.Application.Issuing.Command;

public class DrawLicenseCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public Int64 Serial { get; set; }
    public string Name { get; set; } = string.Empty!;
    public DateTime DateOfBirth { get; set; }
    public int NationalityId { get; set; }
    public int CountryId { get; set; }
    public int AccordingToId { get; set; }
    public string PassportId { get; set; } = string.Empty!;
    public string BloodGroup { get; set; } = string.Empty!;
    public int Gender { get; set; }
    public string PermitClasses { get; set; } = string.Empty!;
    public string PhoneNumber { get; set; } = string.Empty!;
    public DateTime Issued { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string HashedSerial { get; set; } = string.Empty!;
    public int ValidityYears { get; set; }
    public string PersonalPhoto { get; set; } = string.Empty!;
    public int AccountId { get; set; }
}

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class DrawLicenseCommandHandler(
    /*
    IApplicationDbContext context,
    IIdentityService identityService,
    ILogger<DrawLicenseCommandHandler> logger,
    IMediator mediator
*/
) : IRequestHandler<DrawLicenseCommand, bool>
{
    string DateToString(DateTime date) => date.ToString("dd/MM/yyyy");

    string GetGender(int type) => type > 0 ? "Male" : "Female";

    public async Task<bool> Handle(DrawLicenseCommand request, CancellationToken cancellationToken)
    {
        if (!Directory.Exists("E-Licenses/" + request.Id))
        {
            Directory.CreateDirectory("E-Licenses/" + request.Id);
        }

        const string inputImagePath = "/run/media/modsyan/Per/work/Current/MacClientSystem/src/Web/wwwroot/templates/empty.png";
        var outputImagePath = $"E-Licenses/{request.Id}/output-card.png";
        var qRImagePath = $"E-Licenses/{request.Id}/qR-output-card.png";
        // const string image_path = $"C:/Inetpub/vhosts/mac.org.sa/api-online.mac.org.sa/wwwroot/uploads/";
        // string personalImagePath = image_path + request.AccountId + "/1/" + request.Id + "/personal-photo.jpg";
        string finalImagePath = "E-Licenses/" + request.Id + "/final.png";
        const string qrCodeData = "https://online.mac.org.sa/verify/";


        DrawELicenseHelper.WriteOnCardImage(
            inputImagePath,
            outputImagePath,
            request.Name,
            request.PassportId,
            request.BloodGroup,
            request.PermitClasses,
            request.Serial.ToString(),
            GetGender(request.Gender),
            DateToString(request.DateOfBirth),
            DateToString(request.Issued),
            DateToString(request.ExpiryDate),
            CountryDictionary.GetNation(request.NationalityId) ?? string.Empty,
            CountryDictionary.GetStateName(request.CountryId) ?? string.Empty,
            CountryDictionary.GetStateName(request.AccordingToId) ?? string.Empty
        );

        DrawELicenseHelper.QrCodeMaker(
            outputImagePath,
            qRImagePath,
            qrCodeData
        );

        DrawELicenseHelper.DrawPersonalImage(
            request.PersonalPhoto,
            qRImagePath,
            finalImagePath
        );

        // var entity = new License
        // {
        //     Id = Guid.NewGuid(),
        //     IssuedBy = _currentUserService.UserId,
        //     IssuedTo = _currentUserService.UserId,
        //     IssuedOn = _dateTime.Now,
        //     ExpiryDate = _dateTime.Now.AddYears(1),
        //     LicenseType = LicenseType.Full,
        //     LicenseStatus = LicenseStatus.Active
        // };

        // _context.Licenses.Add(entity);

        // await _context.SaveChangesAsync(cancellationToken);

        // await _mediator.Publish(new LicenseIssuedEvent(entity.Id), cancellationToken);

        return true;
    }
}
