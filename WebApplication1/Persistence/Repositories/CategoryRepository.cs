using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains.Models;
using WebApplication1.Persistence.Repository;

namespace WebApplication1.Persistence.repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository 
    {
        public CategoryRepository(AppDBContext context) : base(context) 
        { 
            
        }
        public async Task<IEnumerable<Category>> ListAsync() 
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category) 
        {
            await _context.Categories.AddAsync(category);
        }
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
        public void Remove(Category category) 
        {
            _context.Categories.Remove(category);
        }
    }
}
