using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repos)
        {
            repository = repos;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productID)
        {
            return View(repository.Products.FirstOrDefault(x => x.ProductID == productID));
        }


        [HttpPost]
        public IActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"Zapisano {product.Name}.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public IActionResult Delete(int productID)
        {
            Product deleteProduct = repository.DeleteProduct(productID);
            if (deleteProduct != null)
            {
                TempData["message"] = $"Usunięto {deleteProduct.Name}.";
            }
            return RedirectToAction("Index");
        }
    }
}