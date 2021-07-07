using RestApi.DataAccess.Dapper.Interfaces;
using RestApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Services
{
    public class ProductService:IProductService
    {
        protected readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return _productRepository.GetAllProductAsync();
        }

        public Task<IEnumerable<Product>> GetProductByIdAsync(int id)
        {
            return _productRepository.GetProductByIdAsync(id);
        }
    }
}
