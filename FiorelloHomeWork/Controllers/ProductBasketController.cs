using FiorelloHomeWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using One_to_many_migration.DAL;
using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace FiorelloHomeWork.Controllers
{
    public class ProductBasketController : Controller
    {
        public AppDbContext _context { get; }
        public ProductBasketController(AppDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            var basket = JsonSerializer.Deserialize<List<Product>>(Request.Cookies[""]);
            return View(basket);
        }
    }
}
