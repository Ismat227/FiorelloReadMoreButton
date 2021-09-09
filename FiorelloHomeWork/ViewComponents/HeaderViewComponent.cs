using FiorelloHomeWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using One_to_many_migration.DAL;
using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.ViewComponents
{
    public class HeaderViewComponent: ViewComponent
    {
        public AppDbContext _context { get; }
        public HeaderViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string basket = HttpContext.Request.Cookies["basket"];
            BasketViewModel basketViewModel = new BasketViewModel
            {
                basketItemViewModels = new List<BasketItemViewModel>(),
                TotalPrice = 0,
                Count=0                
            };

            if (basket!=null)
            {
                List<CookieItemViewModel> cookieItemViewModels = JsonConvert.DeserializeObject<List<CookieItemViewModel>>(basket);
                foreach (var cookie in cookieItemViewModels)
                {
                    Product product = _context.Products.FirstOrDefault(p => p.Id == cookie.Id);
                    if (product != null)
                    {
                        BasketItemViewModel basketItemViewModel = new BasketItemViewModel
                        {
                            Product = product,
                            Count = cookie.Count
                        };
                        basketViewModel.basketItemViewModels.Add(basketItemViewModel);
                        basketViewModel.TotalPrice += (decimal)(cookie.Count + product.Price);

                        basketViewModel.Count++;
                    }
                }
            }
            return View(await Task.FromResult(basketViewModel));

        }
    }
}
