using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace One_to_many_migration.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> DeletedTime { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
