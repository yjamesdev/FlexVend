using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Backend.Data
{
    public class DB : DbContext
    {

        public DB(DbContextOptions<DB> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set;}
    }

}
