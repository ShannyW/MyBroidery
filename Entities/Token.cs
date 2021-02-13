using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Entities
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
    }
}
