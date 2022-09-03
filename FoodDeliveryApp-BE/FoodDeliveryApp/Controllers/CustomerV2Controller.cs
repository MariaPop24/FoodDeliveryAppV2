using FoodDeliveryApp.BLL.Interfaces;
using FoodDeliveryApp.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerV2Controller : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomerV2Controller(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet("get-modify")]
        public async Task<IActionResult> GetModify()
        {
            var list = await _customerManager.ModifyCustomer();
            return Ok(list);
        }
    }
}
