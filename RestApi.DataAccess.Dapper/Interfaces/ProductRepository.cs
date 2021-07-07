using Microsoft.Extensions.Configuration;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace RestApi.DataAccess.Dapper.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        protected readonly IConfiguration _config;
        public ProductRepository(IConfiguration config)
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
      

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = @"select productid, productname, p.categoryid, categoryname 
                from product p inner
                join category c on p.categoryid = c.categoryid";
                    var products = await dbConnection.QueryAsync<Product, Category, Product>(query, (product, category) => {
                        product.Category = category;
                        return product;
                    },
    splitOn: "CategoryId");
                    
                    return products;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Product>> GetProductByIdAsync(int id)
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = @"select productid, productname, p.categoryid, categoryname 
                from product p inner
                join category c on p.categoryid = c.categoryid Where p.productid= @Id";
                    var products = await dbConnection.QueryAsync<Product, Category, Product>(query, (product, category) => {
                        product.Category = category;
                        return product;
                    },param:new { Id = id },
    splitOn: "CategoryId");

                    return products;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
