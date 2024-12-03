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
    public class Branch : ControllerBase
    {
        private readonly DB DbContext;

        public Branch(DB DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranch()
        {
            try
            {
                var branch = await DbContext.Branches.ToListAsync();
                var branchList = new List<object>();

                foreach (var branches in branch)
                {
                     branchList.Add(new
                    {
                        branches.Id,
                        branches.CodBranches,
                        branches.CompanyId,
                        branches.Name,
                        branches.Address,
                        branches.PhoneNumber,
                        branches.Email,
                        branches.status,
                        branches.DateCreation,
                        branches.DateUpdate,
                        branches.CountryId,
                        branches.CityId,
                        branches.StateId
                    });

                }

                if (!branchList.Any())
                {
                    return NotFound(new { message = "There are no Branches" });
                }

                return Ok(branchList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Could not get Branches", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetBranch(string name)
        {
            try
            {
                var branches = await DbContext.Branches.FirstOrDefaultAsync(r => r.Name == name);

                if (branches == null)
                {
                    return NotFound(new { message = "This Branch was not found" });
                }

                return Ok(branches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "There was an error searching for Branches", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] Branches model)
        {
            try
            {
                var branches = new Branches()
                {
                       Id = model.Id,
                       CodBranches = model.CodBranches,
                       CompanyId = model.CompanyId,
                       CountryId = model.CountryId,
                       Name = model.Name,
                       Address = model.Address,
                       PhoneNumber = model.PhoneNumber,
                       Email = model.Email,
                       status = model.status,
                       DateCreation = model.DateCreation,
                       DateUpdate = model.DateUpdate,
                       CityId = model.CityId,
                       StateId = model.StateId,
                };

                DbContext.Branches.Add(branches);
                await DbContext.SaveChangesAsync();

                return Ok(CreatedAtAction(nameof(GetAllBranch), new { Id = branches }, branches));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Branches were not created correctly", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("{name}")]
        public async Task<IActionResult> UpdateBranch(string name, [FromBody] Branches model)
        {
            try
            {
                var branches = await DbContext.Branches.FirstOrDefaultAsync(r => r.Name == name);

                if (branches == null)
                {
                    return NotFound(new { message = "This Branch was not found" });
                }

               branches.CodBranches = model.CodBranches;
               branches.CompanyId = model.CompanyId;
               branches.CountryId = model.CountryId;
               branches.Name = model.Name;
               branches.Address = model.Address;
               branches.PhoneNumber = model.PhoneNumber;
               branches.Email = model.Email;
               branches.status = model.status;
               branches.DateCreation = model.DateCreation;
               branches.DateUpdate = model.DateUpdate;
               branches.CityId = model.CityId;
               branches.StateId = model.StateId;

                DbContext.Branches.Update(branches);
                await DbContext.SaveChangesAsync();

                return Ok(new { message = "Branch updated successfully",  branches });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the Branch", error = ex.Message });
            }
        }

        [HttpPatch]
        [Route("{name}/status")]
        public async Task<IActionResult> UpdateBranchStatus(string name, [FromBody] string newStatus)
        {
            try
            {
                var branches = await DbContext.Branches.FirstOrDefaultAsync(r => r.Name == name);

                if (branches == null)
                {
                    return NotFound(new { message = "Branch not found" });
                }

                if (!Enum.TryParse(typeof(Branches.BranchStatus), newStatus, true, out var statusEnum))
                {
                    return BadRequest(new { message = "Invalid status value. Valid values are: Active, No Active" });
                }

                branches.status = (Branches.BranchStatus)statusEnum;
                branches.DateUpdate = DateTime.UtcNow;

                return Ok(new { message = $"Branches status updated to {branches.status}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}
