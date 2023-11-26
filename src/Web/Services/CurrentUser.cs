using System.Security.Claims;

using MacClientSystem.Application.Common.Interfaces;

namespace MacClientSystem.Web.Services;

public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Username => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name) ?? string.Empty;
    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public int AccountId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("account_id") != null ? Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirstValue("AccountId")) : 0;
}
