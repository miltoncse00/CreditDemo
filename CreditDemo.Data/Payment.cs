using System;
using System.ComponentModel.DataAnnotations;

namespace CreditDemo.Data
{
    public class Payment {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Description { get; set; }
        [DataType("decimal(10,2)")]
        public decimal PaymentAmount { get; set; }
        public virtual string SaleId { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
