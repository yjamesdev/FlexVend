using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set;}
        public string Name { get; set;} = string.Empty;
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
    }
}
