using System;

namespace server.Dtos.CV
{
    public class UpdateCvDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string PhoneNumber { get; set; }
        public string Summary{get; set;} = string.Empty;
    }
}
