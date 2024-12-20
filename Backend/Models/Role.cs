using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set;}
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        [MaxLength(255)]
        public string Name { get; set;} = string.Empty;
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
    }
}
