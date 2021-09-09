using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.DAL;
using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        public AppDbContext _context { get;}

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.Where(c=>c.IsDeleted==false));
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View();
            bool hascategory = _context.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
            if (hascategory)
            {
                ModelState.AddModelError("Name", "Bele kateqoriya var");
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            if (id == null) 
                return NotFound();
            var category = _context.Categories.FirstOrDefault(c => c.Id == id&&c.IsDeleted==false);
            if (category == null)
                return NotFound();
            return View(category);           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int? id,Category category)
        {
            if (id == null)
                return NotFound();
            if (id != category.Id)
                return BadRequest();
            var categoryDb = _context.Categories.FirstOrDefault(c => c.Id == id && c.IsDeleted == false);
            if (category == null)
                return NotFound();
            bool hascategory = _context.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
            if (hascategory)
            {
                ModelState.AddModelError("Name", "Bele kateqoriya var");
                return View(categoryDb);
            }
            categoryDb.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
                return NotFound();
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();
            if (category.IsDeleted)
            {
                category.IsDeleted = false;
            }
            else
            {
                category.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
