using System;
using server.Data;
using server.Interfaces;
using server.Model;
using Microsoft.EntityFrameworkCore;


namespace server.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDBContext _context;
        public UserProfileRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<UserProfile?> GetByIdAsync(string id)
        {
            return await _context.UserProfile
            .Include(up => up.Cvs)
                .ThenInclude(cv => cv.Educations)
            .Include(up => up.Cvs)
                .ThenInclude(cv => cv.WorkExperiences)
            .Include(up => up.Cvs)
                .ThenInclude(cv => cv.Languages)
            .FirstOrDefaultAsync(up => up.UserId == id);
        }
    }
}
