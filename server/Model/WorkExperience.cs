using System;

namespace server.Model
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public string CompanyName{ get; set; } = string.Empty;
        public string Descriprion { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CvId { get; set; }
        public CV? Cv {get; set;}
    }
}
