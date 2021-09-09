using One_to_many_migration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.ViewModels
{
    public class BasketItemViewModel
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
