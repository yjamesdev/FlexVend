using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Branches
    {
        public enum BranchStatus
        {
            Active = 1,
            NoActive = 2
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string CodBranches { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CountryId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Address { get; set; } = string.Empty;
        [MaxLength(255)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(255)]
        [EnumDataType(typeof(BranchStatus))]
        public BranchStatus status { get; set; } = BranchStatus.Active;
        public int CityId { get; set; }
        public int StateId { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
    }
}
