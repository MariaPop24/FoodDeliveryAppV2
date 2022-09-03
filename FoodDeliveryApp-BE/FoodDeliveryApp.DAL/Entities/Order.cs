using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Number { get; set; }
        public int DeliveryTime { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}