using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Products
    {
           public enum Status
        {
            Active = 1,
            NoActive = 2
        }

        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Sku { get; set; } = string.Empty;
        public Status status { get; set; } = Status.Active;
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DataUpdate { get; set; } = DateTime.UtcNow;
    }
}
