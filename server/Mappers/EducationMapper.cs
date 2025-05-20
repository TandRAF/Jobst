using System;
using server.Dtos.Education;
using server.Model;

namespace server.Mappers
{
    public static class EducationMapper
    {
        public static EducationDto ToEducationDto(this Education EdModel){
            return new EducationDto
            {
                Id = EdModel.Id,
                DegreeType = EdModel.DegreeType,
                InstituteName = EdModel.InstituteName,
                Descriprion = EdModel.Descriprion,
                StartDate = EdModel.StartDate,
                EndDate = EdModel.EndDate
            };
        }
        public static Education ToEduFromRequest(this RequestEducationDto EdModel, int Id){
            return new Education
            {
                DegreeType = EdModel.DegreeType,
                InstituteName = EdModel.InstituteName,
                Descriprion = EdModel.Descriprion,
                StartDate = EdModel.StartDate,
                EndDate = EdModel.EndDate,
                CvId = Id
            };

        }
    }
}
