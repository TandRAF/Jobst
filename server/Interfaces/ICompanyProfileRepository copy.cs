using System;
using System.Threading.Tasks;
using server.Model;
using server.Dtos.JobOffer;

namespace server.Interfaces
{
    public interface ICompanyProfileRepository
    {
        Task<CompanyProfile?> GetByIdAsync(string id);
        Task<JobOffer?> CreateJobOfferAsync(string userId, RequestJobOfferDTO dto);
    }
}
