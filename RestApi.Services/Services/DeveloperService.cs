using RestApi.DataAccess.Dapper.Interfaces;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Services
{
    public class DeveloperService:IDeveloperService
    {
        protected readonly IDeveloperRepository _developerRepository;
        public DeveloperService(IDeveloperRepository developerRespository)
        {
            _developerRepository = developerRespository;
        }

        public void AddDeveloper(Developer entity)
        {
            _developerRepository.AddDeveloper(entity);
        }

        public void DeleteDeveloper(int id)
        {
            _developerRepository.DeleteDeveloper(id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            return _developerRepository.GetAllDevelopersAsync();
        }

        public Task<IEnumerable<Developer>> GetDevelopersByEmailAsync(string emailId)
        {
            return _developerRepository.GetDevelopersByEmailAsync(emailId);
        }

        public Task<IEnumerable<Developer>> GetDevelopersByIdAsync(int id)
        {
            return _developerRepository.GetDevelopersByIdAsync(id);
        }

        public void UpdateDeveloper(Developer entity)
        {
            _developerRepository.UpdateDeveloper(entity);
        }
    }
}
