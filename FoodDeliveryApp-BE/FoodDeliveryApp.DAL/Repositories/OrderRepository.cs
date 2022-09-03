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
    public class OrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderModels>> GetAll()
        {
            var orders = await (await GetAllQuery()).ToListAsync();
            var list = new List<OrderModels>();

            foreach (var order in orders)
            {
                var orderModel = new OrderModels
                {
                    Number = order.Number,
                    DeliveryTime = order.DeliveryTime,
                };
                list.Add(orderModel);
            }
            return list;
        }

        public async Task<IQueryable<Order>> GetAllQuery()
        {
            var query = _context.Orders.AsQueryable();
            return query;
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            return order;
        }
    }
}
