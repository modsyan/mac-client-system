using Microsoft.AspNetCore.Http;

namespace MacClientSystem.Application.Common.Models.DTOs.Identity;

public class RegisterUserCommand
{
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IFormFile ProfilePicture { get; set; } = null!;
}
