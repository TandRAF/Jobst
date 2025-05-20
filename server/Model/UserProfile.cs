using System;

namespace server.Model
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public UserBase? User { get; set; }
        public List<CV>? Cvs { get; set; } = new List<CV>();
    }
}
