using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.DAL;
using One_to_many_migration.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Products = await _context.Products.Where(p => p.IsDeleted == false).Include(p => p.ProductImages).Include(p => p.Category).OrderByDescending(p=>p.Id).Take(8).ToListAsync(),                
                Title=await _context.Title.FirstOrDefaultAsync(),
                Experts=await _context.Experts.ToListAsync()
            };

            return View(homeviewmodel);

        }
    }
}
