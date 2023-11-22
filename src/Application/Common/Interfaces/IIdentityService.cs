using MacClientSystem.Application.Common.Models;
using MacClientSystem.Application.Common.Models.DTOs.Identity;

namespace MacClientSystem.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);

    Task<LoginResponseDto> AuthenticateAsync(string username, string password);
    
    Task<bool> RegisterUserAsync(RegisterUserCommand cmd);
}
