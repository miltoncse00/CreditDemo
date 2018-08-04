using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CreditDemo.Data
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options)
  : base(options) { }


        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SalesConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
