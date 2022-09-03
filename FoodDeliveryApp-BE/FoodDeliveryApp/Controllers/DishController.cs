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
    public class DishController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DishController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddDish")]
        public async Task<IActionResult> AddDish([FromBody] Dish dish)
        {
            if (string.IsNullOrEmpty(dish.Name))
            {
                return BadRequest("Name is null");
            }

            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetDish([FromRoute] int id)
        {
            var dish = await _context.Dishes.Where(x => x.DishId == id).Include(x => x.Name).FirstOrDefaultAsync();

            return Ok(dish);
        }

        [HttpGet("Get-select")]
        public async Task<IActionResult> GetDishesSelect()
        {
            var dish = await _context.Dishes.Select(x => new { DishId = x.DishId, Name = x.Name, Weight = x.Weight }).ToListAsync();

            return Ok(dish);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDishName([FromQuery] int id, [FromQuery] string name)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(x => x.DishId == id);

            dish.Name = name;

            await _context.SaveChangesAsync();

            return Ok(dish);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDish([FromRoute] int id)
        {
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
