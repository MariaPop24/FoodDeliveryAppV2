using FoodDeliveryApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Helpers
{
    public static class CustomerExtension
    {
        public static IQueryable<Customer> IncludeOrder(this IQueryable<Customer> customers)
        {
            return customers.Include(x => x.Orders);
        }

        public static IQueryable<Customer> WhereClauses(this IQueryable<Customer> customers)
        {
            return customers
                .IncludeOrder()
                .Where(x => x.FirstName == "Mia")
                .Where(x => x.CustomerAddress.City == "Braila")
                .Where(x => x.CustomerAddress.Zipcode == 1234);
        }
    }
}