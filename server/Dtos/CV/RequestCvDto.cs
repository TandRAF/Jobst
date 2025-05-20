using System;

namespace server.Dtos.CV
{
    public class RequestCvDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email {get; set;} = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Summary{get; set;} = string.Empty;
    }
}
