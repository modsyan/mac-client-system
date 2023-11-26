using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;
using MacClientSystem.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MacClientSystem.Infrastructure.Files;

public class FileUploadService(IWebHostEnvironment webHostEnvironment, IOptions<DiskFileOptions> fileOptions)
    : IFileUploadService
{
    public async Task<UploadedFile> SaveToDisk(IFormFile file)
    {
        if (file.Length == 0) throw new Exception("cover is empty");

        var uploadsFolder = $"{webHostEnvironment.WebRootPath}{fileOptions.Value.WwwRootImagePath}";

        var fileId = Guid.NewGuid();
        var genFileName = $"{fileId}{Path.GetExtension(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, genFileName);

        var uploadedFile = new UploadedFile()
        {
            Id = fileId,
            FileName = genFileName,
            OriginalFileName = file.FileName,
            FilePath = filePath,
            ContentType = file.ContentType,
        };

        await using var stream = File.Create(filePath);
        await file.CopyToAsync(stream);
        await stream.DisposeAsync();

        return uploadedFile;
    }

    public async Task<UploadedFileDto> GetFile(UploadedFile file)
    {
        var loadedFile = new UploadedFileDto()
        {
            Id = file.Id,
            Content = Convert.ToBase64String(await File.ReadAllBytesAsync(file.FilePath)),
            FileName = file.FileName,
            OriginalFileName = file.OriginalFileName,
            ContentType = file.ContentType,
            FileSize = new FileInfo(file.FilePath).Length
        };

        return loadedFile;
    }
}
