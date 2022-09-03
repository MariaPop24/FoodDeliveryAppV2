using FoodDeliveryApp.DAL.Entities;
using FoodDeliveryApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Interfaces
{
    public interface ICustomerAddressRepository
    {
        Task<List<CustomerAddressModels>> GetAll();
        Task<CustomerAddress> GetById(int id);
        Task Create(CustomerAddress customerAddress);
        Task Update(CustomerAddress customerAddress);
        Task Delete(CustomerAddress customerAddress);
        Task<IQueryable<CustomerAddress>> GetAllQuery();
    }
}
