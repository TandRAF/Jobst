using System.Collections.Generic;
using System.Threading.Tasks;
using server.Model;
using server.Dtos.JobOffer;

namespace server.Interfaces
{
    public interface IJobOfferRepository
    {
        Task<List<JobOffer>> GetAllAsync();
        Task<JobOffer?> GetByIdAsync(int id);
        Task<JobOffer?> UpdateAsync(int id, RequestJobOfferDTO dto);
        Task<JobOffer?> DeleteAsync(int id);
    }
}