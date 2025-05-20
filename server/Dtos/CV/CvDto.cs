using System;
using server.Dtos.Education;
using server.Dtos.Language;
using server.Dtos.WorkExperience;
using server.Model;
namespace server.Dtos.CV
{
    public class CvDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public List<EducationDto> Educations { get; set; } = new List<EducationDto>();
        public List<WorkExperienceDto> WorkExperiences { get; set; } = new List<WorkExperienceDto>();
        public List<LanguageDto> Language { get; set; } = new List<LanguageDto>();

    }
}
