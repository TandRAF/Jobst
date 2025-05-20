using System;
using server.Dtos.Language;
using server.Model;

namespace server.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllAsync();
        Task<Language?> GetByIdAsync(int id);
        Task<Language?> CreateAsync(Language lanModel);
        Task<Language?> UpdateAsync(int id,RequestLanguageDto workExperienceDto);
        Task<Language?> DeleteAsync(int id);

    }
}
