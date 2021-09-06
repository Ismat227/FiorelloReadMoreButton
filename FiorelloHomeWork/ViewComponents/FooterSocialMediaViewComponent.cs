using Microsoft.AspNetCore.Mvc;
using One_to_many_migration.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.ViewComponents
{
    public class FooterSocialMediaViewComponent:ViewComponent
    {
        public AppDbContext _context { get; }
        public FooterSocialMediaViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _context.SocialMedias;
            return View(await Task.FromResult(model));
        }
    }
}
