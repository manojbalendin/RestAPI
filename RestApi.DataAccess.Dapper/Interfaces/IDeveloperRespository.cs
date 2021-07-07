using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.DataAccess.Dapper.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        Task<IEnumerable<Developer>> GetDevelopersByIdAsync(int id);
        Task<IEnumerable<Developer>> GetDevelopersByEmailAsync(string emailId);
        void AddDeveloper(Developer entity);
        void UpdateDeveloper(Developer entity);
        void DeleteDeveloper(int id);
    }
}
