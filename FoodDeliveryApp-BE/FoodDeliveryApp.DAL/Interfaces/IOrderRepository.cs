using FoodDeliveryApp.DAL.Entities;
using FoodDeliveryApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderModels>> GetAll();
        Task<Order> GetById(int id);
        Task Create(Order order);
        Task Update(Order order);
        Task Delete(Order order);
        Task<IQueryable<Order>> GetAllQuery();
    }
}
