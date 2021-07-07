using Microsoft.Extensions.Configuration;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace RestApi.DataAccess.Dapper.Interfaces
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly IConfiguration _config;
        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public void AddDeveloper(Developer entity)
        {
            try
            {
                using(IDbConnection dbConnection=this.Connection)
                {
                    dbConnection.Open();
                    string query = "INSERT INTO Developer (Name,Email,Department,JoinedDate) VALUES(@Name,@Email,@Department,@JoinedDate);";
                    dbConnection.Execute(query,entity);

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDeveloper(int id)
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = "Delete From Developer Where Id = @Id";                    
                    dbConnection.Execute(query,new { Id = id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = "Select * From Developer";
                    var result = await dbConnection.QueryAsync<Developer>(query);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Developer>> GetDevelopersByEmailAsync(string Email)
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = "Select * From Developer Where Email = @Email";
                    var result = await dbConnection.QueryAsync<Developer>(query,new { Email = Email });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Developer>> GetDevelopersByIdAsync(int id)
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = "Select * From Developer Where Id= @Id";
                    var result = await dbConnection.QueryAsync<Developer>(query, new { Id = id });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDeveloper(Developer entity)
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = "Update Developer Set Name = @Name,Email = @Email,Department = @Department,JoinedDate = @JoinedDate Where Id = @Id);";
                    dbConnection.Execute(query, entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
