using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{

    public class Companies
    {
        public enum Status
        {
            Active = 1,
            NoActive = 2
        }

        [Key]
        public int Id { get; set; }
        public byte[] Photo { get; set; } = new byte[0];
        [MaxLength(50)]
        public string CodCompanies { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Rnc { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Addres { get; set; } = string.Empty;
        [MaxLength(255)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [EnumDataType(typeof(Status))]
        public Status status { get; set; } = Status.Active;
        [MaxLength(255)]
        public string Web { get; set; } = string.Empty;
        [MaxLength(255)]
        public string zipcode { get; set; } = string.Empty;
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DataUpdate { get; set; } = DateTime.UtcNow;
    }
}