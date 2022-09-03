using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Entities
{
    public class CustomerAddress
    {
        [Key]
        public int CustomerAddressId { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}