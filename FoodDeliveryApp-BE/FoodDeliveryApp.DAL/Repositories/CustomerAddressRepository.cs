using FoodDeliveryApp.DAL.Entities;
using FoodDeliveryApp.DAL.Interfaces;
using FoodDeliveryApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Repositories
{
    public class CustomerAddressRepository
    {
        private readonly AppDbContext _context;

        public CustomerAddressRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(CustomerAddress customerAddress)
        {
            await _context.CustomersAddresses.AddAsync(customerAddress);
            await _context.SaveChangesAsync();
        }
        public async Task Update(CustomerAddress customerAddress)
        {
            _context.CustomersAddresses.Update(customerAddress);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CustomerAddress customerAddress)
        {
            _context.CustomersAddresses.Remove(customerAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerAddressModels>> GetAll()
        {
            var customerAddresses = await (await GetAllQuery()).ToListAsync();
            var list = new List<CustomerAddressModels>();

            foreach (var customerAddress in customerAddresses)
            {
                var customerModel = new CustomerAddressModels
                {
                    City = customerAddress.City,
                    Zipcode = customerAddress.Zipcode,

                };
                list.Add(customerModel);
            }
            return list;
        }

        public async Task<IQueryable<CustomerAddress>> GetAllQuery()
        {
            var query = _context.CustomersAddresses.AsQueryable();
            return query;
        }

        public async Task<CustomerAddress> GetById(int id)
        {
            var customerAddress = await _context.CustomersAddresses.FindAsync(id);
            return customerAddress;
        }
    }
}
