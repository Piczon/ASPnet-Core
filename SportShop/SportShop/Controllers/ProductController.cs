using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace SportShop.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository repository) 
        {
            this.repository = repository;
        }
        public ViewResult List(string category) => View(repository.Products.Where(p => p.Category == null || p.Category == category));

        public ViewResult ListAll() => View("List", repository.Products);

        public ViewResult GetById(int id) => View(repository.Products.Single(p => p.ProductID == id));

        public ViewResult Delete(int id) => View(repository.Products.Single(p => p.ProductID == id));

    }
}
