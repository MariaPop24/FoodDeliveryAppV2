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
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            var order = await _context.Orders
                .Where(x => x.OrderId == id)
                .Include(x => x.CustomerId)
                .FirstOrDefaultAsync();

            return Ok(order);
        }

        [HttpGet("Get-select")]
        public async Task<IActionResult> GetOrdersSelect()
        {
            var order = await _context.Orders.Select(x => new { OrderId = x.OrderId, NUmber = x.Number, DeliveryTime = x.DeliveryTime }).ToListAsync();

            return Ok(order);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderNUmber([FromQuery] int id, [FromQuery] int number)
        {
            var order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.OrderId == id);

            order.Number = number;

            _context.Entry(order).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
