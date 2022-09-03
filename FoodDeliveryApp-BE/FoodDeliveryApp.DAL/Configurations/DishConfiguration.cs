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
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(x => x.DishId);
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Weight).HasColumnType("int").HasMaxLength(3);
            builder.Property(x => x.Price).HasColumnType("int").HasMaxLength(3);
        }
    }
}