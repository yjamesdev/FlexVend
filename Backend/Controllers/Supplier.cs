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
    public class Supplier : ControllerBase
    {
           private readonly DB DbContext;

        public Supplier(DB DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var suppliers = await DbContext.Suppliers.ToListAsync();
                var suppliersList = new List<object>();

                foreach (var supplier in suppliers)
                {
                    suppliersList.Add(new
                    {
                        supplier.Id,
                        supplier.CodSuppliers,
                        supplier.Name,
                        supplier.Address,
                        supplier.PhoneNumber,
                        supplier.Email,
                        supplier.status,
                        supplier.CityId,
                        supplier.CountryId,
                        supplier.StateId,
                        supplier.DateCreation,
                        supplier.DateUpdate,
                    });

                }

                if (!suppliersList.Any())
                {
                    return NotFound(new { message = "There are no suppliers" });
                }

                return Ok(suppliersList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Could not get suppliers", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetSupplier(string name)
        {
            try
            {
                var suppliers = await DbContext.Suppliers.FirstOrDefaultAsync(r => r.Name == name);

                if (suppliers == null)
                {
                    return NotFound(new { message = "This Supplier was not found" });
                }

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "There was an error searching for suppliers", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuppliers([FromBody] Suppliers model)
        {
            try
            {
                var suppliers = new Suppliers()
                {
                    CodSuppliers = model.CodSuppliers,
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    status = model.status,
                    CityId = model.CityId,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    DateCreation = model.DateCreation,
                    DateUpdate = model.DateUpdate
                };

                DbContext.Suppliers.Add(suppliers);
                await DbContext.SaveChangesAsync();

                return Ok(CreatedAtAction(nameof(GetAllSuppliers), new { Id = suppliers.Id }, suppliers));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Suppliers were not created correctly", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("{name}")]
        public async Task<IActionResult> UpdateSuppliers(string name, [FromBody] Suppliers model)
        {
            try
            {
                var suppliers = await DbContext.Suppliers.FirstOrDefaultAsync(r => r.Name == name);

                if (suppliers == null)
                {
                    return NotFound(new { message = "This suppliers was not found" });
                }

                DbContext.Suppliers.Update(suppliers);
                await DbContext.SaveChangesAsync();

                return Ok(new { message = "suppliers updated successfully", suppliers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the suppliers", error = ex.Message });
            }
        }

        [HttpPatch]
        [Route("{name}/status")]
        public async Task<IActionResult> UpdateSuppliersrStatus(string name, [FromBody] string newStatus)
        {
            try
            {
                var suppliers = await DbContext.Suppliers.FirstOrDefaultAsync(r => r.Name == name);

                if (suppliers == null)
                {
                    return NotFound(new { message = "suppliers not found" });
                }

                if (!Enum.TryParse(typeof(Suppliers.SuppliersStatus), newStatus, true, out var statusEnum))
                {
                    return BadRequest(new { message = "Invalid status value. Valid values are: Active, NoActive" });
                }

                suppliers.status = (Suppliers.SuppliersStatus)statusEnum;
                suppliers.DateUpdate = DateTime.UtcNow;

                return Ok(new { message = $"suppliers status updated to {suppliers.status}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }
    }
}
