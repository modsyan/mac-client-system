using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.Common.Mappings;

public static class FileHelper
{
    public async static Task<UploadedFileDto>  GetFromDisk(UploadedFile file)
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

    public static string GetFilePath(UploadedFile file)
    {
        return file.FilePath[(file.FilePath.IndexOf("/assets", StringComparison.Ordinal))..];
    }
}
