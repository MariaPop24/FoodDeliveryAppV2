using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.BLL.Interfaces
{
    public interface ICustomerManager
    {
        Task<List<string>> ModifyCustomer();
    }
}
