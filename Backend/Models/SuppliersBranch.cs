using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.Models
{
    public class SuppliersBranch
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
    }
}
