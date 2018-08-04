using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditDemo.Data
{
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.PaymentDate).IsRequired();

            builder.Property(s => s.Description).HasMaxLength(500);
            builder.Property(s => s.PaymentAmount);
            builder.HasOne(s => s.Sale).WithMany(s => s.Payments).HasForeignKey(p => p.SaleId);    


        }
    }
}
