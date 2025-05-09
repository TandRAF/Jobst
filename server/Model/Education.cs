using System;

namespace server.Model
{
    public class Education
    {
        public int Id { get; set; }
        public string DegreeType { get; set; } = string.Empty;
        public string InstituteName { get; set; } = string.Empty;
        public string Descriprion { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CvId { get; set; }
        public CV? Cv {get; set;}

    }
}
