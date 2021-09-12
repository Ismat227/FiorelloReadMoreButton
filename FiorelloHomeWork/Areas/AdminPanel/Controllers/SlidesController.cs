using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            if (ModelState["Photos"].ValidationState==ModelValidationState.Invalid)
            {
                return View();
            }
            foreach (var photo in slide.Photos)
            {
                if (!photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "sekil lazimdi basqa sey yukleme");
                    return View();
                }
                if (photo.Length / 1024 > 300)
                {
                    ModelState.AddModelError("Photo", "sekil  cox yer tutur 300kb-i kecme narmalni");
                    return View();
                }
                string filename = Guid.NewGuid().ToString() + photo.FileName;
                string pathname = Path.Combine(_env.WebRootPath, "img", filename);
                using (FileStream fileStream = new FileStream(pathname, FileMode.Create))
                {
                    await photo.CopyToAsync(fileStream);
                }
                Slide newSlide = new Slide
                {
                    Image = filename
                };
                _context.Add(newSlide);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var slides = _context.Slides.FirstOrDefault(s => s.Id == id);
            if (slides == null)
            {
                return BadRequest();
            }
            else if (id != slides.Id)
            {
                return BadRequest();
            }


            string PathName = Path.Combine(_env.WebRootPath, "img", slides.Image);
            FileInfo file = new FileInfo(PathName);
            file.Delete();

            _context.Slides.Remove(slides);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
