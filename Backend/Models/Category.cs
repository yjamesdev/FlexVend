using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Category
    {
        public enum Status
        {
            Active = 1,
            NoActive = 2
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public int CompanyId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        public int? Subcategory { get; set; }
        [EnumDataType(typeof(Status))]
        public Status status { get; set; } = Status.Active;
        public DateTime DateCreation { get; set; }
        public DateTime DataUpdate { get; set; }
    }
}
