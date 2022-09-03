using FoodDeliveryApp.BLL.Interfaces;
using FoodDeliveryApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.BLL.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerManager(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public async Task<List<string>> ModifyCustomer()
        {
            var customers = await _customerRepo.GetAll();
            var list = new List<string>();

            foreach (var customer in customers)
            {
                list.Add($"CustomerName: {customer.FirstName}");
            }

            return list;
        }
    }
}
