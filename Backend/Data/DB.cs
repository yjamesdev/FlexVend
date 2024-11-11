using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Backend.Data
{
    public class DB: IdentityDbContext<IdentityUser>
    {
         public DB(DbContextOptions options): base(options)
        {
            
        }
    }
}