using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Suppliers
    {
          public enum SuppliersStatus
        {
            Active = 1,
            NoActive = 2
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string CodSuppliers { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Name  { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(255)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        public SuppliersStatus status { get; set; } = SuppliersStatus.Active;
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
    }
}
