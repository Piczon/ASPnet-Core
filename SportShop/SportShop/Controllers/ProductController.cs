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
        public ViewResult List() => View(repository.Products);

        public ViewResult ListAll() => View("List", repository.Products);

    }
}
