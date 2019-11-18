
using Microsoft.AspNetCore.Mvc;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repos;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            repos = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repos.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
