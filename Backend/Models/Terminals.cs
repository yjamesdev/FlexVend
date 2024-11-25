using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Terminals
    {
        public enum Status
        {
            Active = 1,
            NoActive = 2
        }


        [Key]
        public int Id { get; set;}
        public int CompanyId { get; set;}
        public int BranchId { get; set;}
        [MaxLength(50)]
        public string CodTerminal { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;
        [EnumDataType(typeof(Status))]
        public Status status { get; set; } = Status.Active;
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;
    }
}
