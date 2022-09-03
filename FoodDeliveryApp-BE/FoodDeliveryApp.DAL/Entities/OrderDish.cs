using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Entities
{
    public class OrderDish
    {
        public int OrderDishId { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public virtual Order Order { get; set; }
        public virtual Dish Dish { get; set; }
    }
}