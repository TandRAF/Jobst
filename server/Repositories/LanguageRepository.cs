using System;
using server.Data;
using server.Dtos.Language;
using Microsoft.EntityFrameworkCore;
using server.Interfaces;
using server.Model;

namespace server.Repositories
{
    public class LanguageRepository:ILanguageRepository
    {
         private readonly ApplicationDBContext _context;
        private readonly ICvRepository _cvRepository;
        public LanguageRepository(ApplicationDBContext context, ICvRepository cvRepository)
        {
            _context = context;
            _cvRepository = cvRepository;
        }
        public async Task<List<Language>> GetAllAsync()
        {
            return await _context.Language.ToListAsync();
        }

        public async Task<Language?> GetByIdAsync(int id)
        {
            return await _context.Language.FirstOrDefaultAsync(lang => lang.Id == id);
        }
        public async Task<Language?> CreateAsync(Language lanModel)
        {
            await _context.AddAsync(lanModel);
            await _context.SaveChangesAsync();
            return lanModel;
        }
        public async Task<Language> UpdateAsync(int id, RequestLanguageDto requestLanguageDto)
        {
            var edModel = _context.Language.FirstOrDefault(ed => ed.Id == id);
            if (edModel == null)
            {
                return null;
            }
           
            return edModel;
        }
        public async Task<Language> DeleteAsync(int id)
        {
            var edModel = _context.Language.FirstOrDefault(ed => ed.Id == id);
            if (edModel == null)
            {
                return null;
            }
            _context.Language.Remove(edModel);
            await _context.SaveChangesAsync();
            return edModel;
        }
    }
}
