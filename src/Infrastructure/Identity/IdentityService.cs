using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MacClientSystem.Application.Common.Interfaces;
using MacClientSystem.Application.Common.Models;
using MacClientSystem.Application.Common.Models.DTOs.Identity;
using MacClientSystem.Infrastructure.Identity.DTOs;
using MacClientSystem.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MacClientSystem.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IMapper _mapper;
    private readonly JwtOptions _jwt;
    private readonly IWebHostEnvironment _env;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService, IMapper mapper, IWebHostEnvironment env, IOptions<JwtOptions> jwt)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _mapper = mapper;
        _env = env;
        _jwt = jwt.Value;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password,string nationalId)
    {
        var user = new ApplicationUser { UserName = userName, Email = userName, NationalId=nationalId};

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    #region JWT

    public async Task<ApplicationUserDto?> GetUserAsync(string username)
    {
        var applicationUser = await _userManager.Users
            .Where(u => u.NormalizedUserName == username.ToUpper())
            // .Include(x => x.ClaimsCountries).ThenInclude(u => u.AccountsStockTypes)
            .Include(u => u.ProfilePicture)
            .ProjectTo<ApplicationUserDto>(_mapper.ConfigurationProvider)
            .AsSingleQuery()
            .FirstOrDefaultAsync();

        return applicationUser;
    }

    public async Task<bool> CheckPasswordAsync(string userId, string password)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        return user != null && (_env.EnvironmentName == "Development"
                                || await _userManager.CheckPasswordAsync(user, password));
    }

    public async Task<IList<string>?> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null) return null;

        var stringRoles = await _userManager.GetRolesAsync(user);

        // var roles= stringRoles.Select(r => ((int)(SecurityRole)Enum.Parse(typeof(SecurityRole), r)).ToString())
        //     .ToList();

        return stringRoles;
    }

    public async Task<LoginResponseDto> AuthenticateAsync(string username, string password)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username || u.Email == username);

        if (user is null) throw new Exception("User not found");

        var result = await _userManager.CheckPasswordAsync(user, password);

        if (result == false) throw new Exception("Invalid password");

        var token = await GenerateToken(user);

        return new LoginResponseDto { Token = token, };
    }

    public async Task<bool> RegisterUserAsync(RegisterUserCommand cmd)
    {
        var user = new ApplicationUser { UserName = cmd.Username, Email = cmd.Email,NationalId= cmd.NationalId};


        var result = await _userManager.CreateAsync(user, cmd.Password);

        // return (result.ToApplicationResult(), user.Id);
        return true;
    }

    private async Task<string> GenerateToken(ApplicationUser user)
    {
        
        var userClaims = await _userManager.GetClaimsAsync(user);
        var userRoles = await _userManager.GetRolesAsync(user);
        var roleClaims = userRoles.Select(role => new Claim("roles", role)).ToList();

        var emailClaim = new Claim(ClaimTypes.Email, user.Email!);
        var userIdClaim = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
        var accountIdClaim = new Claim("account_id", (user.AccountId?? 0).ToString(), ClaimValueTypes.Integer32);

        var claims = new[] { emailClaim, userIdClaim, accountIdClaim }
            .Union(userClaims)
            .Union(roleClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwt.DurationsInDays),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    #endregion
}
