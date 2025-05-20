using System;
using Azure.Core;
using server.Dtos.Education;
using server.Model;

namespace server.Interfaces
{
    public interface IEducationRepository
    {
        Task<List<Education>> GetAllAsync();
        Task<Education?> GetByIDAsync(int id);
        Task<Education?> CreateAsync(Education eduModel);
        Task<Education?> UpdateAsync(int id, RequestEducationDto requestEducationDto);
        Task<Education?> DeleteAsync(int id);
     
    }
}
