namespace MacClientSystem.Infrastructure.Services.MacSys.OnlineApi.Models;

public class CreateUserCommand
{
    public required int AccountId { get; set; }

    public required string[] Names { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Password { get; set; }
}
