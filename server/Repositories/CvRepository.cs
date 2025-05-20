using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interfaces;
using server.Model;
using server.Mappers;
using server.Dtos.CV;

namespace server.Repositories
{
    public class CvRepository : ICvRepository
    {
        private readonly ApplicationDBContext _context;
        public CvRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<CV>> GetAllAsync()
        {
            return await _context.CV.Include(Edu => Edu.Educations)
            .Include(We => We.WorkExperiences)
            .Include(Lan => Lan.Languages).ToListAsync();
        }
        public async Task<CV?> GetByIdAsync(int id)
        {
            return await _context.CV
            .Include(Edu => Edu.Educations)
            .Include(We => We.WorkExperiences)
            .Include(We => We.Languages)
            .FirstOrDefaultAsync(cv => cv.UserProfileId == id);
        }
        public async Task<CV?> CreateAsync(CV cvModel, UserBase user)
        {
            var userProfile = await _context.UserProfile.FirstOrDefaultAsync(p => p.UserId == user.Id);
            if (userProfile == null)
                return null;

            cvModel.UserProfileId = userProfile.Id;
            await _context.CV.AddAsync(cvModel);
            await _context.SaveChangesAsync();
            return cvModel;
        }

        public async Task<bool> ExistCv(int id)
        {
            return await _context.CV.AnyAsync(cv => cv.Id == id);
        }
        public async Task<CV?> UpdateAsync(int id, UpdateCvDto updateCvDto)
        {
            var cvModel = _context.CV.FirstOrDefault(cv => cv.Id == id);
            if (cvModel == null)
            {
                return null;
            }
            cvModel.Name = updateCvDto.Name;
            cvModel.Surname = updateCvDto.Surname;
            cvModel.Email = updateCvDto.Email;
            cvModel.PhoneNumber = updateCvDto.PhoneNumber;
            cvModel.Summary = updateCvDto.Summary;
            await _context.SaveChangesAsync();
            return cvModel;
        }
        public async Task<CV?> DeleteAsync(int id)
        {
            var cvModel = _context.CV.FirstOrDefault(cv => cv.Id == id);
            if (cvModel == null)
            {
                return null;
            }
            _context.CV.Remove(cvModel);
            await _context.SaveChangesAsync();
            return cvModel;
        }
    }
}
