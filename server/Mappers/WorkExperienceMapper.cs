using System;
using server.Dtos.WorkExperience;
using server.Model;

namespace server.Mappers
{
    static public class WorkExperienceMapper
    {
        public static WorkExperienceDto ToWorkExperienceDto(this WorkExperience workExperience)
        {
            return new WorkExperienceDto
            {
                Id = workExperience.Id,
                PostTitle = workExperience.PostTitle,
                CompanyName = workExperience.CompanyName,
                Descriprion = workExperience.Descriprion,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate
            };
        }
        public static WorkExperience FromRequestToWorkExperience(this WorkExperienceDto workExperienceDto,int id)
        {
            return new WorkExperience
            {
                PostTitle = workExperienceDto.PostTitle,
                CompanyName = workExperienceDto.CompanyName,
                Descriprion = workExperienceDto.Descriprion,
                StartDate = workExperienceDto.StartDate,
                EndDate = workExperienceDto.EndDate,
                CvId = id
            };
        }
    }
}
