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
                var companies = await DbContext.Companies.ToListAsync();
                var CompaniesList = new List<object>();

                foreach (var company in companies)
                {
                    CompaniesList.Add(new
                    {
                       company.Id,
                       Photo = Convert.ToBase64String(company.Photo),
                       company.CodCompanies,
                       company.Name,
                       company.Rnc,
                       company.Addres,
                       company.PhoneNumber,
                       company.Email,
                       company.status,
                       company.DateCreation,
                       company.DateUpdate,
                       company.Web,
                       company.zipcode,
                       company.CityId,
                       company.CountryId,
                       company.StateId,
                    });

                }

                if (!CompaniesList.Any())
                {
                    return NotFound(new { message = "There are no Companies" });
                }

                return Ok(CompaniesList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Could not get Companies", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetCompanies(string name)
        {
            try
            {
                var company = await DbContext.Companies.FirstOrDefaultAsync(r => r.Name == name);

                if (company == null)
                {
                    return NotFound(new { message = "This Companies was not found" });
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "There was an error searching for Companies", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Companies model)
        {
            try
            {
                 model.Id = 0;
                var company = new Companies()
                {
                       Photo = model.Photo,
                       CodCompanies = model.CodCompanies,
                       Name = model.Name,
                       Rnc = model.Rnc,
                       Addres = model.Addres,
                       PhoneNumber = model.PhoneNumber,
                       Email = model.Email,
                       status = model.status,
                       Web = model.Web,
                       zipcode = model.zipcode,
                       CityId = model.CityId,
                       CountryId = model.CountryId,
                       StateId = model.StateId,
                       DateCreation = model.DateCreation,
                       DateUpdate = model.DateUpdate
                };

                DbContext.Companies.Add(company);
                await DbContext.SaveChangesAsync();

                return Ok(CreatedAtAction(nameof(GetAllCompanies), new { Id = company }, company));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Companies were not created correctly", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("{name}")]
        public async Task<IActionResult> UpdateCompany(string name, [FromBody] Role model)
        {
            try
            {
                var role = await DbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);

                if (role == null)
                {
                    return NotFound(new { message = "This Role was not found" });
                }

                role.CompanyId = model.CompanyId;
                role.BranchId = model.BranchId;
                role.Name = model.Name;
                role.Description = model.Description;

                DbContext.Roles.Update(role);
                await DbContext.SaveChangesAsync();

                return Ok(new { message = "Roles updated successfully", role });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the roles", error = ex.Message });
            }
        }

        [HttpPatch]
        [Route("{name}/status")]
        public async Task<IActionResult> UpdateCompaniesStatus(string name, [FromBody] string newStatus)
        {
            try
            {
                var company = await DbContext.Companies.FirstOrDefaultAsync(r => r.Name == name);

                if (company == null)
                {
                    return NotFound(new { message = "Companies not found" });
                }

                if (!Enum.TryParse(typeof(Companies.CompanyStatus), newStatus, true, out var statusEnum))
                {
                    return BadRequest(new { message = "Invalid status value. Valid values are: Active, No Active" });
                }

                company.status = (Companies.CompanyStatus)statusEnum;
                company.DateUpdate = DateTime.UtcNow;

                return Ok(new { message = $"Companies status updated to {company.status}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

    }
}
