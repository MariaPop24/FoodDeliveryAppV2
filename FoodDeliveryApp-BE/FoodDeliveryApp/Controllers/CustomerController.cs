using FoodDeliveryApp.DAL;
using FoodDeliveryApp.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
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
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName))
            {
                return BadRequest("FirstName is null");
            }
            if (string.IsNullOrEmpty(customer.LastName))
            {
                return BadRequest("LastName is null");
            }
            if (string.IsNullOrEmpty(customer.Mail))
            {
                return BadRequest("Mail is null");
            }
            if (string.IsNullOrEmpty(customer.PhoneNumber))
            {
                return BadRequest("PhoneNumber is null");
            }

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _context.Customers.Where(x => x.CustomerId == id).Include(x => x.CustomerAddress).FirstOrDefaultAsync();

            return Ok(customer);
        }

        [HttpGet("Get-select")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetCustomersSelect()
        {
            var customer = await _context.Customers.Select(x => new { CustomerId = x.CustomerId, FirstName = x.FirstName, LastName = x.LastName }).ToListAsync();

            return Ok(customer);

        }

        [HttpGet("Get-join")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetCustomerJoin()
        {
            var customer = await _context.Customers.Include(x => x.CustomerId).ToListAsync();

            return Ok(customer);

        }

        [HttpGet("Get-order-by")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetCustomerOrderBy()
        {
            var customer = await _context.Customers.Include(x => x.FirstName).OrderByDescending(x => x.LastName).ToListAsync();

            return Ok(customer);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);

            customer.FirstName = name;

            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpGet("jazy-lazy")]
        public async Task<IActionResult> JoinLazy()
        {
            var customers = _context.Customers.AsQueryable();

            return Ok(customers);
        }

        [HttpGet("get-group-by")]
        public async Task<IActionResult> GetGroupBy()
        {
            var deliveryTimeAverage = _context.Orders.GroupBy(x => x.CustomerId).Select(x => new
            {
                Key = x.Key,
                Average = x.Average(x => x.DeliveryTime)
            }).ToList();

            return Ok(deliveryTimeAverage);
        }

        [HttpGet("get-join-linq")]
        public async Task<IActionResult> GetJoinLinq()
        {
            var customers = _context.Customers;
            var join = _context.Orders.Join(customers, b => b.CustomerId, a => a.OrderId, (b, a) => new
            {
                b.CustomerId,
                b.DeliveryTime,
                a.FirstName
            }).ToList();

            return Ok(join);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
