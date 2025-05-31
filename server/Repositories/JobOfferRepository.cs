using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Model;
using server.Mappers;
using server.Dtos.JobOffer;

namespace server.Repositories
{
    public class JobOfferRepository : IJobOfferRepository
    {
        private readonly ApplicationDBContext _context;
        public JobOfferRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<JobOffer>> GetAllAsync()
        {
            return await _context.JobOffer.ToListAsync();
        }

        public async Task<JobOffer?> GetByIdAsync(int id)
        {
            return await _context.JobOffer.FirstOrDefaultAsync(jo => jo.Id == id);
        }

        public async Task<JobOffer?> UpdateAsync(int id, RequestJobOfferDTO dto)
        {
            var jobOffer = await _context.JobOffer.FirstOrDefaultAsync(jo => jo.Id == id);
            if (jobOffer == null) return null;

            jobOffer.JobTitle = dto.JobTitle;
            jobOffer.CompanyTitle = dto.CompanyTitle;
            jobOffer.CompanyImageUrl = dto.CompanyImageUrl;
            jobOffer.DatePosted = dto.DatePosted;
            jobOffer.Tags = dto.Tags ?? new List<string>();

            await _context.SaveChangesAsync();
            return jobOffer;
        }

        public async Task<JobOffer?> DeleteAsync(int id)
        {
            var jobOffer = await _context.JobOffer.FindAsync(id);
            if (jobOffer == null) return null;
            _context.JobOffer.Remove(jobOffer);
            await _context.SaveChangesAsync();
            return jobOffer;
        }
    }
}
