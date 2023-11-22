using System.ComponentModel.DataAnnotations;

namespace MacClientSystem.Application.Common.Models.DTOs.Identity;

public class LoginDto
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
