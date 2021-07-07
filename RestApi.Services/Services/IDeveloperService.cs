using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        Task<IEnumerable<Developer>> GetDevelopersByIdAsync(int id);
        Task<IEnumerable<Developer>> GetDevelopersByEmailAsync(string emailId);
        void AddDeveloper(Developer entity);
        void UpdateDeveloper(Developer entity);
        void DeleteDeveloper(int id);
    }
}
