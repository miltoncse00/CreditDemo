using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Text;

namespace CreditDemo.Data
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options)
  : base(options) { }


        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public long GetSaleNo()
        {

            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            Database.ExecuteSqlCommand(
                       "SELECT @result = (NEXT VALUE FOR DBSequence)", result);

            return Convert.ToInt64(result.Value);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<long>("DBSequence")
                            .StartsAt(1000).IncrementsBy(1);
            modelBuilder.Entity<Sale>()
               .Property(x => x.Id)
               .HasDefaultValueSql("NEXT VALUE FOR DBSequence");

            modelBuilder.ApplyConfiguration(new SalesConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
