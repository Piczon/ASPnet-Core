using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.ViewComponents
{
    //public class CategoryViewComponent : ViewComponent
    //{
    //    private ApplicationDBContext ctx;

    //    public CategoryViewComponent(ApplicationDBContext ctx)
    //    {
    //        this.ctx = ctx;
    //    }

    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
            
            
    //        ViewBag.SelectedCategory = RouteData?.Values["category"];
    //        return View(ctx.Products.Select(x => x.Category).Distinct().ToList());
    //    }
    //}
}
