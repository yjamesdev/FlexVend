using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Auth
    {
     [Required]
     [MaxLength(50)]
     public string Username { get; set; }

     [Required]
     [MaxLength(255)]
     public string Password { get; set; }
    }
}
