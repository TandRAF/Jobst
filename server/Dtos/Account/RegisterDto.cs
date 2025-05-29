using System;
using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? UserName {get;set;}
        [Required]
        [EmailAddress]
        public string? Email {get;set;}
        [Required]
        public string? Role { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
