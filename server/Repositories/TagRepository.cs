using System;
using server.Data;
using server.Interfaces;
using server.Model;
using Microsoft.EntityFrameworkCore;


namespace server.Repositories
{
    public class TagRepository:ITagRepository
    {
        private readonly ApplicationDBContext _context;
        public TagRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<Tag?> GetByIdAsync(int id)
        {
            return await _context.Tag.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
