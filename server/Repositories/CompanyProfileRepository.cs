using System;
using server.Data;
using server.Interfaces;
using server.Model;
using Microsoft.EntityFrameworkCore;
using server.Dtos.JobOffer;


namespace server.Repositories
{
    public class CompanyProfileRepository:ICompanyProfileRepository
    {
        private readonly ApplicationDBContext _context;
        public CompanyProfileRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<CompanyProfile?> GetByIdAsync(string id)
        {
            return await _context.CompanyProfile
                .Include(cp => cp.JobOffers)
                .FirstOrDefaultAsync(cp => cp.UserId == id);
        }

        public async Task<JobOffer?> CreateJobOfferAsync(string userId, RequestJobOfferDTO dto)
        {
            var companyProfile = await _context.CompanyProfile.FirstOrDefaultAsync(cp => cp.UserId == userId);
            if (companyProfile == null) return null;

            var jobOffer = new JobOffer
            {
                JobTitle = dto.JobTitle,
                CompanyTitle = dto.CompanyTitle,
                CompanyProfileId = companyProfile.Id,
                DatePosted = dto.DatePosted,
                CompanyImageUrl = dto.CompanyImageUrl ?? "",
                Tags = dto.Tags ?? new List<string>()
            };

            await _context.JobOffer.AddAsync(jobOffer);
            await _context.SaveChangesAsync();
            return jobOffer;
        }
    }
}
