using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }  
        public int Price { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }    
        public List<Product> Products { get; set; }
    }
}
