using FoodDeliveryApp.DAL;
using FoodDeliveryApp.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerAddressController(AppDbContext context)
        {
            _context = context;
        }



        [HttpPost("AddDish")]
        public async Task<IActionResult> AddCustomerAddress([FromBody] CustomerAddress customerAddres)
        {
            if (string.IsNullOrEmpty(customerAddres.City))
            {
                return BadRequest("City is null");
            }

            await _context.CustomersAddresses.AddAsync(customerAddres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCustomerAddress([FromRoute] int id)
        {
            var customerAddres = await _context.CustomersAddresses.Where(x => x.CustomerAddressId == id).Include(x => x.City).FirstOrDefaultAsync();

            return Ok(customerAddres);
        }

        [HttpGet("Get-select")]
        public async Task<IActionResult> GetCustomersAddressesSelect()
        {
            var customerAddres = await _context.CustomersAddresses.Select(x => new { CustomerAddressId = x.CustomerAddressId, City = x.City, Zipcode = x.Zipcode }).ToListAsync();

            return Ok(customerAddres);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAddressCityName([FromQuery] int id, [FromQuery] string name)
        {
            var customerAddres = await _context.CustomersAddresses.FirstOrDefaultAsync(x => x.CustomerAddressId == id);

            customerAddres.City = name;

            await _context.SaveChangesAsync();

            return Ok(customerAddres);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomerAddress([FromRoute] int id)
        {
            var customerAddres = await _context.CustomersAddresses.FindAsync(id);
            if (customerAddres == null)
            {
                return NotFound();
            }

            _context.CustomersAddresses.Remove(customerAddres);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
