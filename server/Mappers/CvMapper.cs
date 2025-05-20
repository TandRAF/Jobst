using System;
using server.Dtos.CV;
using server.Model;

namespace server.Mappers
{
    public static class CvMapper
    {
        public static CvDto ToCvDto(this CV CvModel){
            return new CvDto
            {
                Id = CvModel.Id,
                Name = CvModel.Name,
                Surname = CvModel.Surname,
                Email = CvModel.Email,
                PhoneNumber = CvModel.PhoneNumber,
                Summary = CvModel.Summary,
            };
        }
        public static CV ToCvFromRequest(this RequestCvDto CvModel){
            return new CV
            {
                Name = CvModel.Name,
                Surname = CvModel.Surname,
                Email = CvModel.Email,
                PhoneNumber = CvModel.PhoneNumber,
                Summary = CvModel.Summary
            };

        }
    }
}
