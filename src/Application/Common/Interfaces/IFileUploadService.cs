using MacClientSystem.Application.Common.Models;
using MacClientSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace MacClientSystem.Application.Common.Interfaces;

public interface IFileUploadService
{
    public Task<UploadedFile> UploadFormFile(IFormFile file);
    public UploadedFileDto DownloadFormFile(UploadedFile file);
}
