using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Entities
{
    public class RolePrivilege
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public string Privilege { get; set; }
    }
}
