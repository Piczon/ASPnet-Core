using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class EFManufacturerRepository : IManufacturer
    {
        private readonly ApplicationDBContext ctx;

        public EFManufacturerRepository(ApplicationDBContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<Manufacturer> Manufacturers => ctx.Manufacturers;
    }
}
