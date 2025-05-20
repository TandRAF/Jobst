using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Education;
using server.Interfaces;
using server.Model;

namespace server.Repositories
{
    public class EducationRepositroy : IEducationRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ICvRepository _cvRepository;
        public EducationRepositroy(ApplicationDBContext context, ICvRepository cvRepository)
        {
            _context = context;
            _cvRepository = cvRepository;
        }
        public async Task<List<Education>> GetAllAsync()
        {
            return await _context.Education.ToListAsync();
        }

        public async Task<Education?> GetByIDAsync(int id)
        {
            return await _context.Education.FirstOrDefaultAsync(edu => edu.Id == id);
        }
        public async Task<Education?> CreateAsync(Education eduModel)
        {
            await _context.AddAsync(eduModel);
            await _context.SaveChangesAsync();
            return eduModel;
        }
        public async Task<Education> UpdateAsync(int id, RequestEducationDto educationDto)
        {
            var edModel = _context.Education.FirstOrDefault(ed => ed.Id == id);
            if (edModel == null)
            {
                return null;
            }
            edModel.DegreeType = educationDto.DegreeType;
            edModel.InstituteName = educationDto.InstituteName;
            edModel.Descriprion = educationDto.Descriprion;
            edModel.StartDate = educationDto.StartDate;
            edModel.EndDate = educationDto.EndDate;
            return edModel;
        }
        public async Task<Education> DeleteAsync(int id)
        {
            var edModel = _context.Education.FirstOrDefault(ed => ed.Id == id);
            if (edModel == null)
            {
                return null;
            }
            _context.Education.Remove(edModel);
            await _context.SaveChangesAsync();
            return edModel;
        }
    }
}
