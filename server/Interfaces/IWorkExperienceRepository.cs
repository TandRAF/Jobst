using System;
using server.Dtos.WorkExperience;
using server.Model;

namespace server.Interfaces
{
    public interface IWorkExperienceRepository
    {
        Task<List<WorkExperience>> GetAllAsync();
        Task<WorkExperience?> GetByIdAsync(int id);
        Task<WorkExperience?> CreateAsync(WorkExperience weModel);
        Task<WorkExperience?> UpdateAsync(int id,RequestWorkExperienceDto workExperienceDto);
        Task<WorkExperience?> DeleteAsync(int id);
    }
}
