using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Roles : ControllerBase
    {
        private readonly DB DbContext;

        public Roles(DB DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetRoles()
        {
            try
            {
                var Role = await DbContext.Roles.ToListAsync();
                var RoleList = new List<object>();

                foreach (var roles in Role)
                {

                    RoleList.Add(new
                    {
                        roles.Id,
                        roles.Name,
                        roles.Description
                    });

                }

                if (!RoleList.Any())
                {
                    return NotFound(new { message = "There are no Roles" });
                }

                return Ok(RoleList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Could not get Roles", error = ex.Message });
            }
        }


        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetRole(string name)
        {
            try
            {
                var roles = await DbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);

                if (roles == null)
                {
                    return NotFound(new { message = "This Role was not found" });
                }

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "There was an error searching for Roles", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] Role model)
        {
            try
            {
                var role = new Role()
                {
                    BranchId = model.BranchId,
                    CompanyId = model.CompanyId,
                    Name = model.Name,
                    Description = model.Description,
                };

                DbContext.Roles.Add(role);
                await DbContext.SaveChangesAsync();

                return Ok(CreatedAtAction(nameof(GetRole), new { Id = role }, role));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Roles were not created correctly", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("{name}")]
        public async Task<IActionResult> UpdateRoles(string name, [FromBody] Role model)
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

                return Ok(new { message = "Rolesupdated successfully", role });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the roles", error = ex.Message });
            }
        }


    }
}
