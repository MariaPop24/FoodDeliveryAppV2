using FoodDeliveryApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.DAL.Configuration
{
    public class OrderDishConfiguration : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure(EntityTypeBuilder<OrderDish> builder)
        {
            builder.HasOne(p => p.Order).WithMany(p => p.OrderDishes).HasForeignKey(p => p.OrderId);
            builder.HasOne(p => p.Dish).WithMany(p => p.OrderDishes).HasForeignKey(p => p.DishId);
        }
    }
}