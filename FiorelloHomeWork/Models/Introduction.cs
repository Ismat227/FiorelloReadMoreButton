using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace One_to_many_migration.Models
{
    public class Introduction
    {
        public int Id { get; set; }
        public string HeaderTitle { get; set; }
        public string SmallTitle { get; set; }
        [Required, StringLength(255)]
        public string Image { get; set; }

    }
}
