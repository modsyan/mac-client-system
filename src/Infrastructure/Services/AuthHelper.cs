using System.Text;
using System.Text.Json;
using MacClientSystem.Infrastructure.Services.MacSys.OnlineApi.Models;

namespace MacClientSystem.Infrastructure.Services;

public class JwtToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiry { get; set; }
}

public static class AuthHelpers
{
    public static async Task<string> GetAccessTokenAsync(string tokenUrl, string username, string password)
    {
        var httpClient = new HttpClient();

        var login = new AuthCommand { Username = username, Password = password, RememberMe = true };

        var loginDtoJson = new StringContent(
            JsonSerializer.Serialize(login),
            Encoding.UTF8,
            "application/json"
        );

        var response = await httpClient.PostAsync(tokenUrl, loginDtoJson);

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();

        var jwtToken = await JsonSerializer.DeserializeAsync<JwtToken>(responseStream);

        return jwtToken!.Token;
    }
}
