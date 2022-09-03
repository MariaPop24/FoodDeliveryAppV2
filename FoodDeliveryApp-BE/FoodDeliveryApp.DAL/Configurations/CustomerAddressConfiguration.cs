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
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(x => x.CustomerAddressId);
            builder.Property(x => x.City).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Zipcode).HasColumnType("int").HasMaxLength(6);

        }
    }
}