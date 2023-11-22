using MacClientSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MacClientSystem.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    
    public int AccountId { get; set; }
    public virtual Account Account { get; set; } = null!;
    
    public Guid? ProfilePictureId { get; set; }
    public virtual UploadedFile ProfilePicture { get; set; } = null!;
}
