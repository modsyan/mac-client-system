#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
using System.ComponentModel;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Issuing.Command.Helpers;
using MacClientSystem.Domain.Entities;
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
    public string UserId { get; set; } = string.Empty;
    public int AccountId { get; set; } 
}

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class DrawLicenseCommandHandler(
    IApplicationDbContext context
    /*
    IIdentityService identityService,
    ILogger<DrawLicenseCommandHandler> logger,
    IMediator mediator
*/
    
) : IRequestHandler<DrawLicenseCommand, bool>
{
    
    // private readonly IWebHostEnvironment _env;
    
    string DateToString(DateTime date) => date.ToString("dd/MM/yyyy");

    string GetGender(int type) => type > 0 ? "Male" : "Female";

    public async Task<bool> Handle(DrawLicenseCommand request, CancellationToken cancellationToken)
    {
        
        const string eLicensePath = "wwwroot/assets/uploads/E-Licenses/";
        
        if (!Directory.Exists(eLicensePath + request.Id))
        {
            Directory.CreateDirectory(eLicensePath + request.Id);
        }

        //TODO: REMOVE IT TO appsettings.json and use OptionPattern
        const string inputImagePath = "wwwroot/templates/empty.png";
        var outputImagePath = $"{eLicensePath}/{request.Id}/output-card.png";
        var qRImagePath = $"{eLicensePath}/{request.Id}/qR-output-card.png";
        
        // const string image_path = $"C:/Inetpub/vhosts/mac.org.sa/api-online.mac.org.sa/wwwroot/uploads/";
        // string personalImagePath = image_path + request.AccountId + "/1/" + request.Id + "/personal-photo.jpg";
        
        // TODO: REMOVE IT AND USE WebEnvironment TO GET THE PATH
        // TODO: MOVE TO FileService to Save the output license to save in uploads folder
        string finalImagePath = $"{eLicensePath}/{request.Id}/final.png";
        
        const string qrCodeData = "https://online.mac.org.sa/verify/";

        // TODO: REMOVE IT TO appsettings.json and use OptionPattern
        // TODO: REMOVE HARDCODE Just For Test
        // string personalImagePath = $"https://api-online.mac.org.sa/uplaods/{request.AccountId}/1/{request.UserId}/personal-photo.jpg";
        //TODO: PersonalImageUrl Must Passed from the request
        string personalImagePath = $"C:/Inetpub/vhosts/mac.org.sa/api-online.mac.org.sa/wwwroot/uploads/{request.AccountId}/1/{request.UserId}/personal-photo.jpg";
        // string personalImagePath = $"C:/Inetpub/vhosts/mac.org.sa/api-online.mac.org.sa/wwwroot/uploads/{request.AccountId}/1/{request.UserId}/personal-photo.jpg";
        
        // https://api-online.mac.org.sa//uploads/1/1/0001ec22-0000-0000-0000-000000000000/personal-photo.jpg
        // string personalImagePath = $"https://api-online.mac.org.sa/uploads/{request.AccountId}/1/{request.UserId}/personal-photo.jpg";
        

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

        await DrawELicenseHelper.DrawPersonalImage(
            // personalImagePath,
            request.PersonalPhoto,
            qRImagePath,
            finalImagePath
        );

        
        var uploadedFile = new UploadedFile
        {
            Id = request.Id,
            FileName = "final.png",
            FilePath = finalImagePath,
            FileSize = 0,
        };

        var entity = new ExternalIssuedLicense
        {
            LicenseOrderId = request.Id,
            Serial = request.Serial,
            Name = request.Name,
            Issued = request.Issued,
            ExpiryDate = request.ExpiryDate,
            UserId = request.UserId,
            AccountId = request.AccountId,
            LicenseImagePathId = request.Id,
            LicenseImagePath = uploadedFile, 
        };
        
        await context.ExternalIssuedLicenses.AddAsync(entity, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        // await _mediator.Publish(new LicenseIssuedEvent(entity.Id), cancellationToken);
        
        return true;
    }
}
