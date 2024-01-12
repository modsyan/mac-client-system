using MacClientSystem.Infrastructure.Services.MacSys.OnlineApi.Models;
using Refit;

namespace MacClientSystem.Infrastructure.Services.MacSys.OnlineApi;

public interface IOnlineApi
{
    [Post("/security/auth")]
    Task<IApiResponse<JwtToken>> Authenticate(AuthCommand cmd);

    [Post("/security/user")]
    Task<IApiResponse<Guid?>> CreateUser(CreateUserCommand cmd);
}
