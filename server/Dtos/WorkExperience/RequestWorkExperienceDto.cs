using System;

namespace server.Dtos.WorkExperience
{
    public class RequestWorkExperienceDto
    {
        public string PostTitle { get; set; } = string.Empty;
        public string CompanyName{ get; set; } = string.Empty;
        public string Descriprion { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
