using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Company : ControllerBase
    {
        private readonly DB DbContext;

        public Company(DB DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var Companys = await DbContext.Companies.ToListAsync();
                var CompaniesList = new List<object>();

                foreach (var company in Companies)
                {

                    CompaniesList.Add(new
                    {
                       company.CodUser,
                       company.CompanyId,
                       company.BranchId,
                       Photo = Convert.ToBase64String(Companies.),
                       company.Username,
                       company.RoleId,
                       company.Email,
                       company.FullName,
                       company.PhoneNumber,
                       company.status,
                       company.DateCreation,
                       company.DateUpdates
                    });

                }

                if (!CompaniesList.Any())
                {
                    return NotFound(new { message = "There are no users" });
                }

                return Ok(CompaniesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Could not get Roles", error = ex.Message });
            }
        }

    }
}
