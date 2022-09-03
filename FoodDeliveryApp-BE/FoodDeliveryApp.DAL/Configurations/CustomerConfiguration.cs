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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.LastName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Mail).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasColumnType("nvarchar(100)").HasMaxLength(10);
        }
    }
}