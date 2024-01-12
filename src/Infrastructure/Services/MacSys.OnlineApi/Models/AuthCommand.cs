namespace MacClientSystem.Infrastructure.Services.MacSys.OnlineApi.Models;

public class AuthCommand
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public bool RememberMe { get; set; }
}
