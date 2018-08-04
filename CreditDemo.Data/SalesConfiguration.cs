using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace CreditDemo.Data
{
    public class SalesConfiguration:IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasMaxLength(12).IsRequired();
            builder.Property(s => s.CustomerId).HasMaxLength(12).IsRequired(); ;
            builder.Property(s => s.TimeStamp).IsRequired(); ;
            builder.Property(s => s.LocationName).HasMaxLength(500);
            builder.Property(s => s.OperatorName).HasMaxLength(500).IsRequired();
            builder.Property(s => s.OpeningDebit);
            builder.Property(s => s.Currency).HasMaxLength(50);
            builder.Property(s => s.SaleInvoiceNumber).HasMaxLength(50).IsRequired();
            builder.HasMany(s => s.Payments);

        }
    }
}
