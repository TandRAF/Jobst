using System;
using Microsoft.AspNetCore.Identity;

namespace server.Model
{
    public class UserBase:IdentityUser
    {
    public string Role { get; set; } = string.Empty;
    public virtual UserProfile? UserProfile { get; set; }
    public virtual CompanyProfile? CompanyProfile { get; set; }
    }
}
