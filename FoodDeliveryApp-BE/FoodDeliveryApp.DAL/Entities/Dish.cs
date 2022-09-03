using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Entities
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public virtual ICollection<OrderDish> OrderDishes { get; set; }
    }
}