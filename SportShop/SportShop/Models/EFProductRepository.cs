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


        public Product DeleteProduct(int productID)
        {
            Product deleteItem = ctx.Products.FirstOrDefault(x => x.ProductID == productID);

            if(deleteItem != null)
            {
                ctx.Products.Remove(deleteItem);
                ctx.SaveChanges();
            }

            return deleteItem;
        }

        public void SaveProduct(Product product)
        {
            if(product.ProductID == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                Product saveItem = ctx.Products.FirstOrDefault(x => x.ProductID == product.ProductID);

                if(saveItem != null)
                {
                    saveItem.Name = product.Name;
                    saveItem.Description = product.Description;
                    saveItem.Price = product.Price;
                    saveItem.Category = product.Category;
                }
            }
            ctx.SaveChanges();
        }
        
    }
}
