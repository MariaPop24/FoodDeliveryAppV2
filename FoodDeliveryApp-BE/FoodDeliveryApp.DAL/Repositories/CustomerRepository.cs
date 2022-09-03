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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CustomerModels>> GetAll()
        {
            var customers = await (await GetAllQuery()).ToListAsync();
            var list = new List<CustomerModels>();

            foreach (var customer in customers)
            {
                var customerModel = new CustomerModels
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Mail = customer.Mail,
                    PhoneNumber = customer.PhoneNumber
                };
                list.Add(customerModel);
            }
            return list;
        }

        public async Task<IQueryable<Customer>> GetAllQuery()
        {
            var query = _context.Customers.AsQueryable();
            return query;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }


    }
}
