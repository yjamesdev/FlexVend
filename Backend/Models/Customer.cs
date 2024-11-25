using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string CodCostumer { get; set; } = string.Empty;
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Adress { get; set; } = string.Empty;
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
    }
}
