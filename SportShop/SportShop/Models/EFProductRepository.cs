using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext ctx;
        public EFProductRepository(ApplicationDBContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<Product> Products => ctx.Products;

    }
}
