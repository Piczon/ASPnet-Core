using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportShop.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: /<controller>/

        private readonly IManufacturer manufacturerRepository;
        public ManufacturerController(IManufacturer manufacturerRepository)
        {
            this.manufacturerRepository = manufacturerRepository;
        }
        public ViewResult List() => View(manufacturerRepository.Manufacturers);
    }
}
