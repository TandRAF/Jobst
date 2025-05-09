using System;

namespace server.Model
{
    public class CV
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public string Surname { get; set; } = string.Empty;
        public string Email {get; set;} = string.Empty;
        public int PhoneNumber { get; set; }
        public string Summary{get; set;} = string.Empty;
        public List<Education> Educations {get; set;} = new List<Education>();
        public List<WorkExperience> WorkExperiences {get; set;} = new List<WorkExperience>();
        public List<Language> Languages {get; set;} = new List<Language>();
    }
}
