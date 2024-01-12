using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacClientSystem.Infrastructure.MacOfflineAPI.Models;
public class ProfileVm  
{
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string[] Names { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Avatar { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}
