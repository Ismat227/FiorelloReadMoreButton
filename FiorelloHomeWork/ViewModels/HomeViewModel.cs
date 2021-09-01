using FiorelloHomeWork.Models;
using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One_to_many_migration.ViewModels
{
    public class HomeViewModel
    {
        public List<Slide> Slides { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Introduction Introduction { get; set; }
        public FlowerTitle Title { get; set; }
        public List<Expert> Experts { get; set; }


    }
}
