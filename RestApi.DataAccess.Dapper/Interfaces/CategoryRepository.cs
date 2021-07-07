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
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly IConfiguration _config;
        public CategoryRepository(IConfiguration config)
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
      

       

        public async Task<IEnumerable<Category>> GetCategoryByIdAsync(int CategoryId)
        {
            try
            {
                using (IDbConnection dbConnection = this.Connection)
                {
                    dbConnection.Open();
                    string query = @"select p.categoryid, categoryname , productid, productname
                from product p inner
                join category c on p.categoryid = c.categoryid Where C.Categoryid= @CategoryId";
                    var products = await dbConnection.QueryAsync<Category, Product, Category>(query, (category, products) => {
                        //products.Category = category;
                        category.Products = new List<Product>();
                        category.Products.Add(products);
                        return category;
                    },param:new { CategoryId = CategoryId },
    splitOn: "CategoryId,ProductId");

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
