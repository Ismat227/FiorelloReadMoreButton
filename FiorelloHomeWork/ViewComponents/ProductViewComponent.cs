using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.ViewComponents
{
    public class ProductViewComponent: ViewComponent
    {
        public AppDbContext _context { get; }
        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            var model = await _context.Products.Include(p => p.ProductImages).Where(p => p.IsDeleted == false).
            OrderByDescending(p => p.Id).Take(take).ToListAsync();
            return View(await Task.FromResult(model));
        }
    }
}
