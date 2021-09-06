using FiorelloHomeWork.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.DAL;
using One_to_many_migration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace One_to_many_migration.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel homeviewmodel = new HomeViewModel
            {
                Slides = await _context.Slides.ToListAsync(),
                Introduction = await _context.Introduction.FirstOrDefaultAsync(),
                Categories = await _context.Categories.Where(c => c.IsDeleted == false).ToListAsync(),
                Title =await _context.Title.FirstOrDefaultAsync(),
                Experts=await _context.Experts.ToListAsync(),                              
            };
            //HttpContext.Session.SetString("name", "ismet");
            //List<ProductBasket> baskets = new List<ProductBasket>
            //{
            //    new ProductBasket{Id=1,Count=3},
            //    new ProductBasket{Id=2,Count=2},
            //    new ProductBasket{Id=3,Count=5},
            //    new ProductBasket{Id=4,Count=3}
            //};
            //Response.Cookies.Append("basket",JsonSerializer.Serialize(baskets));
            return View(homeviewmodel);
        }
        public IActionResult AddBasket()
        {
            //string sesionData = HttpContext.Session.GetString("name");
            List < ProductBasket> cookiedata = JsonSerializer.Deserialize<List<ProductBasket>>(Request.Cookies[""]);
            return Json(cookiedata);
        }
    }
}
