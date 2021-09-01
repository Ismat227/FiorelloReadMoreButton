using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One_to_many_migration.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }        
        public double Price { get; set; }
        public int Count { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> DeletedTime { get; set; }

    }
}
