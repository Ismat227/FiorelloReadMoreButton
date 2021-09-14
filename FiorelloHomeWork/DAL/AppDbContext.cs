using FiorelloHomeWork.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One_to_many_migration.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Introduction> Introduction { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<FlowerTitle> Title { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<HeaderLogo> Logo { get; set; }
        public DbSet<FooterSocialMedia> SocialMedias { get; set; }
    }
}
