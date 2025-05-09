using System;
using Microsoft.AspNetCore.Identity;

namespace server.Model
{
    public class UserBase:IdentityUser
    {
        public override string? UserName { get; set; } = string.Empty;
        public override string? Email { get; set; } = string.Empty;
        public string? Password {get; set;} = string.Empty;
        public override string? PhoneNumber {get; set;} = string.Empty;
        public CV Cv = new CV();
    }
}
