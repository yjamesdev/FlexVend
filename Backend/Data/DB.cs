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
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Branches> Branches { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Terminals> Terminals { get; set; }

    }

}
