using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.DAL;
using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SlidesController : Controller
    {
        public AppDbContext _context { get;}
        public IWebHostEnvironment _env { get;}

        public SlidesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View( _context.Slides);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slide slide)
        {
            if (ModelState["Photo"].ValidationState==ModelValidationState.Invalid)
            {
                return View();
            }
            if (!slide.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "sekil lazimdi basqa sey yukleme");
                return View();
            }
            if (slide.Photo.Length/1024>300)
            {
                ModelState.AddModelError("Photo", "sekil  cox yer tutur 300kb-i kecme narmalni");
                return View();
            }
            string filename = Guid.NewGuid().ToString() + slide.Photo.FileName;
            string pathname = Path.Combine(_env.WebRootPath, "img", filename);
            using (FileStream fileStream = new FileStream(pathname, FileMode.Create))
            {
                await slide.Photo.CopyToAsync(fileStream);
            }
            Slide newSlide = new Slide
            {
                Image = filename
            };
            _context.Add(newSlide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var slide = _context.Slides.Find(id);
            if (slide == null) return NotFound();

            string currentimg = slide.Image;
            _context.Entry(slide).State = EntityState.Deleted;
            if (System.IO.File.Exists(currentimg))
            {
                System.IO.File.Delete(currentimg);
            }
            return RedirectToAction(nameof(Index));

            
        }
    }
}
