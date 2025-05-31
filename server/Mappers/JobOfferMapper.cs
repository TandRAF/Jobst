using System;
using server.Dtos.JobOffer;
using server.Model;

namespace server.Mappers
{
    public static class JobOfferMapper
    {
        public static JobOfferDTO ToResponseDTO(JobOffer jobOffer)
        {
            return new JobOfferDTO
            {
                Id = jobOffer.Id,
                JobTitle = jobOffer.JobTitle,
                CompanyTitle = jobOffer.CompanyTitle,
                DatePosted = jobOffer.DatePosted,
                CompanyImageUrl = jobOffer.CompanyImageUrl,
                Tags = jobOffer.Tags?.ToList() ?? new List<string>()
            };
        }

        public static JobOffer ToJobOffer(RequestJobOfferDTO dto, int companyProfileId)
        {
            return new JobOffer
            {
                CompanyProfileId = companyProfileId,
                JobTitle = dto.JobTitle ?? "",
                CompanyTitle = dto.CompanyTitle ?? "",
                DatePosted = dto.DatePosted,
                CompanyImageUrl = dto.CompanyImageUrl ?? "",
                Tags = dto.Tags ?? new List<string>()
            };
        }
    }
}
