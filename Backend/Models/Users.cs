using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Users
    {
        public enum Status
        {
            Active = 1,
            NoActive = 2
        }


        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string CodUser { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public byte[] Photo { get; set; } = new byte[0];

        [MaxLength(255)]
        public string Username { get; set; } = string.Empty;
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(255)]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(255)]
        public string PhoneNumber { get; set; } = string.Empty;

        [NotMapped]
        public Status status { get; set; } = Status.Active;

        [MaxLength(50)]
        public string StatusString
        {
            get => status == Status.Active ? "Active" : "No Active";
            set
            {
                if (value == "Active")
                    status = Status.Active;
                else if (value == "No Active")
                    status = Status.NoActive;
            }
        }

        public DateTime DateCreation { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
