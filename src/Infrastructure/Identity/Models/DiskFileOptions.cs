namespace MacClientSystem.Infrastructure.Identity.Models;

public class DiskFileOptions
{
    public const string DiskFileOptionSectionName = "DiskFileOptions";

    public string WwwRootImagePath { get; set; } = string.Empty;
    public string AllowedImageExtensions { get; set; } = string.Empty;
    public string AllowedAudioExtensions { get; set; } = string.Empty;
    public int MaxImageSizeInMb { get; set; }
    public int MaxAudioSizeInMb { get; set; }
}
