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
    public class User : ControllerBase
    {
        private readonly DB DbContext;

        public User(DB DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Users = DbContext.Users.ToList();
                var UsersList = new List<object>();

                foreach (var user in Users)
                {
                    var roles = await DbContext.Roles
                                .Where(ur => ur.Id == user.Id)
                                .Join(DbContext.Roles, ur => ur.Id, role => role.Id, (ur, role) => role.Name)
                                .ToListAsync();

                    UsersList.Add(new
                    {
                        user.Id,
                        user.CodUser,
                        user.CompanyId,
                        user.BranchId,
                        Photo = Convert.ToBase64String(user.Photo),
                        user.Username,
                        user.RoleId,
                        user.Email,
                        user.FullName,
                        user.PhoneNumber,
                        user.status,
                        user.DateCreation,
                        user.DateUpdate,
                        roles
                    });

                }

                if (!UsersList.Any())
                {
                    return NotFound(new { message = "There are no users" });
                }

                return Ok(UsersList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Could not get users", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUsers(Guid id)
        {
            try
            {
                var user = await DbContext.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound(new { message = "This user was not found" });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "There was an error searching for users", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers([FromBody] Users model)
        {
            try
            {
                var User = new Users()
                {
                    CompanyId = model.CompanyId,
                    BranchId = model.BranchId,
                    Photo = model.Photo,
                    Username = model.Username,
                    Password = model.Password,
                    RoleId = model.RoleId,
                    Email = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    status = model.status,
                    DateCreation = model.DateCreation,
                    DateUpdate = model.DateCreation
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

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUsers(Guid id, [FromBody] Users model)
        {
            try
            {
                var user = DbContext.Users.Find(id);

                if (user == null)
                {
                    return NotFound(new { message = "This user was not found" });
                }

                user.CompanyId = model.CompanyId;
                user.BranchId = model.BranchId;
                user.Photo = model.Photo;
                user.Username = model.Username;
                user.Password = model.Password;
                user.RoleId = model.RoleId;
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.PhoneNumber = model.PhoneNumber;
                user.status = model.status;
                user.DateUpdate = DateTime.UtcNow;

                DbContext.Users.Update(user);
                await DbContext.SaveChangesAsync();

                return Ok(new { message = "User updated successfully", user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the user", error = ex.Message });
            }
        }

        [HttpPatch]
        [Route("{id:guid}/status")]
        public async Task<IActionResult> UpdateUserStatus(Guid id, [FromBody] string newStatus)
        {
            try
            {
                var user = await DbContext.Users.FindAsync(id);

                if (user == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                if (!Enum.TryParse(typeof(Users.Status), newStatus, true, out var statusEnum))
                {
                    return BadRequest(new { message = "Invalid status value. Valid values are: Active, NoActive" });
                }

                user.status = (Users.Status)statusEnum;
                user.DateUpdate = DateTime.UtcNow;

                return Ok(new { message = $"User status updated to {user.status}" });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
    }
