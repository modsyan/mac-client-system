using MacClientSystem.Application.Common.Mappings;
using MacClientSystem.Domain.Entities;

namespace MacClientSystem.Application.Common.Models;

public class UploadedFileDto : IMapFrom<UploadedFile>
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string OriginalFileName { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long FileSize { get; set; }

    public UploadedFileDto() { }

    public UploadedFileDto(Guid id, string content, string fileName, string originalFileName, string? contentType, long fileSize)
    {
        this.Id = id;
        this.Content = content;
        this.FileName = fileName;
        this.OriginalFileName = originalFileName;
        this.ContentType = contentType;
        this.FileSize = fileSize;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UploadedFile, UploadedFileDto>()
            .ForMember(desc => desc.Content, opt => opt.MapFrom(src => src.FilePath))
            .ForMember(desc => desc.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(desc => desc.OriginalFileName, opt => opt.MapFrom(src => src.OriginalFileName))
            .ForMember(desc => desc.ContentType, opt => opt.MapFrom(src => src.ContentType))
            .ForMember(desc => desc.FileSize, opt => opt.MapFrom(src => src.FileSize))
            .ForMember(desc => desc.Id, opt => opt.MapFrom(src => src.Id));
    }
}
