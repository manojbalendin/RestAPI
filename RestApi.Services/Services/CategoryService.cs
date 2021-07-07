using RestApi.DataAccess.Dapper.Interfaces;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Services
{
    public class CategoryService:ICategoryService
    {
        protected readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<Category>> GetCategoryByIdAsync(int id)
        {
            return _categoryRepository.GetCategoryByIdAsync(id);
        }
    }
}
