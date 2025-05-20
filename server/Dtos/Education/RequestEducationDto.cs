using System;

namespace server.Dtos.Education
{
    public class RequestEducationDto
    {
        public string DegreeType { get; set; } = string.Empty;
        public string InstituteName { get; set; } = string.Empty;
        public string Descriprion { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
