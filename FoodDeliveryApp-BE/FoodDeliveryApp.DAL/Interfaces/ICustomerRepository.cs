using FoodDeliveryApp.DAL.Entities;
using FoodDeliveryApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerModels>> GetAll();
        Task<Customer> GetById(int id);
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(Customer customer);
        Task<IQueryable<Customer>> GetAllQuery();
    }
}
