using System;
using System.Linq;
using server.Dtos.CompanyProfile;
using server.Model;
using server.Mappers;

namespace server.Mappers
{
    public static class CompanyProfileMapper
    {
        public static CompanyProfileDto ToCompanyProfileDto(this CompanyProfile cpModel)
        {
            return new CompanyProfileDto
            {
                Id = cpModel.Id,
                JobOffers = cpModel.JobOffers
                    .Select(JobOfferMapper.ToResponseDTO)
                    .ToList()
            };
        }
    }
}
