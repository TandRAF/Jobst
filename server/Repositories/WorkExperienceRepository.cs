using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.WorkExperience;
using server.Interfaces;
using server.Model;

namespace server.Repositories
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly ApplicationDBContext _context;
        public WorkExperienceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<WorkExperience?> CreateAsync(WorkExperience weModel)
        {
            await _context.AddAsync(weModel);
            await _context.SaveChangesAsync();
            return weModel;
        }

        public async Task<WorkExperience?> DeleteAsync(int id)
        {
            var weModel = _context.WorkExperience.FirstOrDefault(we => we.Id == id);
            if (weModel == null)
            {
                return null;
            }
            _context.WorkExperience.Remove(weModel);
            await _context.SaveChangesAsync();
            return weModel;

        }

        public async Task<List<WorkExperience>> GetAllAsync()
        {
            return await _context.WorkExperience.ToListAsync();
        }

        public async Task<WorkExperience?> GetByIdAsync(int id)
        {
            return await _context.WorkExperience.FirstOrDefaultAsync(we => we.Id == id);
        }

        public async Task<WorkExperience?> UpdateAsync(int id, RequestWorkExperienceDto reqWeDto)
        {
            var weModel = _context.WorkExperience.FirstOrDefault(we => we.Id == id);
            if (weModel == null)
            {
                return null;
            }
            weModel.PostTitle = reqWeDto.PostTitle;
            weModel.CompanyName = reqWeDto.CompanyName;
            weModel.Descriprion = reqWeDto.Descriprion;
            weModel.StartDate = reqWeDto.StartDate;
            weModel.EndDate = reqWeDto.EndDate;
            await _context.SaveChangesAsync();
            return weModel;
        }
    }
}
