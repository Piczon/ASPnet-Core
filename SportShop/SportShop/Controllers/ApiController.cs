using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

namespace SportShop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IProductRepository repository;

        public ApiController(IProductRepository repo)
        {
            repo = repository;
        }
        /// <summary>
        /// Returns Everything
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("GetEverything")]
        public ActionResult<IEnumerable<Product>> List(string category)
        {
            return Ok(repository.Products.Where(p => p.Category == category));
        }

        /// <summary>
        /// Finding by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("GetById")]
        public ActionResult<Product> GetById(int id)
        {
            var productId = repository.Products.Where(p => p.ProductID == id);
            if(productId == null)
            {
                return NotFound();
            }
            return Ok(productId);
        }

        /// <summary>
        /// Adding Products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        [HttpPost("PostAddProduct")]
        public ActionResult<Product> AddProduct(Product product)
        {
            repository.SaveProduct(product);

            return CreatedAtAction(nameof(GetById), new { id = product}, product);
        }

        /// <summary>
        /// Edit products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>

        [HttpPut("PutUpdateProduct")]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else if(!repository.Products.Any(p => p.ProductID == product.ProductID))
            {
                return NotFound();
            }


            repository.SaveProduct(product);
            return NoContent();
        }


        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteProductID")]
        public IActionResult Delete(int id)
        {
            repository.DeleteProduct(id);
            return NoContent();
        }
    }
}