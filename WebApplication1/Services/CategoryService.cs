using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Domains.Communication;
using WebApplication1.Domains.Models;
using WebApplication1.Domains.Repositories;
using WebApplication1.Domains.Services;
using WebApplication1.Persistence.Repository;

namespace WebApplication1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) 
        {
            _repository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync() 
        {
            return await _repository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _repository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Um erro ocorreu durante o salvamente da cetegory: { ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category) 
        {
            var existingCategory = await _repository.FindByIdAsync(id);

            if (existingCategory == null) 
            {
                return new CategoryResponse("Category not Found.");
            }
            existingCategory.Name = category.Name;
            try
            {
                _repository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch(Exception ex) 
            { 
                return new CategoryResponse($"An error occurred when updateing the category: { ex.Message }");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id) 
        {
            var existingCategory = await _repository.FindByIdAsync(id);

            if (existingCategory == null) 
            {
                return new CategoryResponse("category not Found.");
            }

            try
            {
                _repository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex) 
            {
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}
