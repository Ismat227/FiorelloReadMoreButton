
using FiorelloHomeWork.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using One_to_many_migration.DAL;
using One_to_many_migration.Models;
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
        public IActionResult AddBasket(int id)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            string basket = HttpContext.Request.Cookies["basket"];
            if (basket==null)
            {
                List<CookieItemViewModel> products = new List<CookieItemViewModel>();
                products.Add(new CookieItemViewModel
                {
                    Id=product.Id,
                    Count=1
                    
                });
                string basketstr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("basket", basketstr);
                              
            }
            else
            {
                List<CookieItemViewModel> products = JsonConvert.DeserializeObject<List<CookieItemViewModel>>(basket);
                CookieItemViewModel cookieItem = products.FirstOrDefault(p => p.Id == product.Id);
                if (cookieItem==null)
                {
                    products.Add(new CookieItemViewModel
                    {
                        Id = product.Id,
                        Count = 1

                    });
                }
                else
                {
                    cookieItem.Count++;
                }
                string basketstr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("basket", basketstr);
                

            }
            
            return RedirectToAction("Index", "Home");
            
        }
        public IActionResult ShowBasket()
        {
            return Content(HttpContext.Request.Cookies["basket"]);
        }

        public IActionResult DeleteCookies(int id)
        {
            string basket = HttpContext.Request.Cookies["basket"];
            List<CookieItemViewModel> products = JsonConvert.DeserializeObject<List<CookieItemViewModel>>(basket);
            foreach (var item in products)
            {
                if (item.Id==id)
                {
                    products.Remove(item);
                    break;
                }
            }
            string basketstr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("basket", basketstr);
            return RedirectToAction("Index","Home");

        }
    }
}
