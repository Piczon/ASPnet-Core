﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Product DeleteProduct(int productID);
        void SaveProduct(Product product);
    }
}
