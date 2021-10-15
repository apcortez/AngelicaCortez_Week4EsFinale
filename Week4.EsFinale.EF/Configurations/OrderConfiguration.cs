using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Configurations
{
   public class OrderConfiguration  : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.OrderCode).IsRequired();
            builder.Property(o => o.ProductCode).IsRequired();
            builder.Property(o => o.Price).HasColumnType("decimal(10,2)");
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);

        }
    }
}
