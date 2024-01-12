using Microsoft.AspNetCore.Http;

namespace MacClientSystem.Application.Common.Models.DTOs.Identity;

public class RegisterUserCommand
{
    public string FullName { get; set; } = null!;
    public required string Username { get; set; }
    public required string Password { get; set; } 
    public required string Email { get; set; }
    public string NationalId { get; set; } = null!;

    public IFormFile ProfilePicture { get; set; } = null!;
}
