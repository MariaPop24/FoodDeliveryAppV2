using FoodDeliveryApp.DAL.Entities;
using FoodDeliveryApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Repositories
{
    public class DishRepository
    {
        private readonly AppDbContext _context;

        public DishRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Dish dish)
        {
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Dish dish)
        {
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Dish dish)
        {
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DishModels>> GetAll()
        {
            var dishes = await (await GetAllQuery()).ToListAsync();
            var list = new List<DishModels>();

            foreach (var dish in dishes)
            {
                var dishModel = new DishModels
                {
                    Name = dish.Name,
                    Weight = dish.Weight,
                    Price = dish.Price,
                };
                list.Add(dishModel);
            }
            return list;
        }

        public async Task<IQueryable<Dish>> GetAllQuery()
        {
            var query = _context.Dishes.AsQueryable();
            return query;
        }

        public async Task<Dish> GetById(int id)
        {
            var customer = await _context.Dishes.FindAsync(id);
            return customer;
        }
    }
}
