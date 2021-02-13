using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Image { get; set; }

        public double Price { get; set; }
        public int CreatedById { get; set; }
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        public DateTime Created { get; set; }
        
    }
}
