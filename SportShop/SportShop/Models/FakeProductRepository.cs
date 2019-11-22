using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Pilka nozna", Price = 25 },
            new Product { Name = "Deska Surfingowa", Price = 179 },
            new Product { Name = "Buty", Price = 100 },
        }.AsQueryable<Product>();

        public Product DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
