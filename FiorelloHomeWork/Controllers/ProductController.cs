using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.Controllers
{
    public class ProductController : Controller
    {
        public AppDbContext _context { get; }
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ProductCount = _context.Products.Where(p => p.IsDeleted == false).Count();
            return View(await _context.Products.Include(p=>p.ProductImages).Where(p=>p.IsDeleted==false)
                .OrderByDescending(p => p.Id).Take(12).ToListAsync()
                );
        }
        public async Task<IActionResult> ReadMore(int take=8 ,int skip=12) 
        {
            var model = await _context.Products.Include(p => p.ProductImages).Where(p => p.IsDeleted == false)
                .OrderByDescending(p=>p.Id).Skip(skip).Take(take).ToListAsync();
            return PartialView("_productPartial", model);
        }
    }
}
