using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Persistence.Repository
{
    public interface ICategoryRepository 
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category cateogry);
        Task<Category> FindByIdAsync(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}
