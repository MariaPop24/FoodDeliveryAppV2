using FoodDeliveryApp.DAL.Entities;
using FoodDeliveryApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Interfaces
{
    public interface IDishRepository
    {
        Task<List<DishModels>> GetAll();
        Task<Dish> GetById(int id);
        Task Create(Dish dish);
        Task Update(Dish dish);
        Task Delete(Dish dish);
        Task<IQueryable<Dish>> GetAllQuery();
    }
}
