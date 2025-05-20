using System;
using server.Model;
using server.Dtos.CV;

namespace server.Interfaces
{
    public interface ICvRepository
    {
        Task<List<CV>> GetAllAsync();
        Task<CV?> GetByIdAsync(int id);
        Task<CV?> CreateAsync(CV cvModel,UserBase user);
        Task<CV?> UpdateAsync(int id,UpdateCvDto updateCvDto);
        Task<CV?> DeleteAsync(int id);
        Task<bool> ExistCv(int id);
    }
}
