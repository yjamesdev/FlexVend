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
                var Role =  await DbContext.Roles.ToListAsync();
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
        public async Task<IActionResult> CreateUsers([FromBody] Role model)
        {
            try
            {
                var Role = new Users()
                {

                };

                DbContext.Users.Add(User);
                await DbContext.SaveChangesAsync();

                return Ok(CreatedAtAction(nameof(GetAllUsers), new { Id = User.Id }, User));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Users were not created correctly", error = ex.Message });
            }
        }

}
}
