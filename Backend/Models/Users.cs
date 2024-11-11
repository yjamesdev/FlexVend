using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Users
    {
        [Key]
        public int Id  { get; set;}
        public string CodUser { get; set;} = string.Empty;
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public byte[] Photo { get; set; } = new byte[0];
        public string Username { get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; } 
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Status { get; set; } 
        public DateTime DateCreation { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}