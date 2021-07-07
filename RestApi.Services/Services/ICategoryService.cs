using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoryByIdAsync(int id);
    }
}
