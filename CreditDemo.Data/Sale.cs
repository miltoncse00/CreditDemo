using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CreditDemo.Data
{
    public class Sale
    {
        public Sale()
        {
            this.Payments = new HashSet<Payment>();
        }
         public string Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string LocationName { get; set; }
        public string OperatorName { get; set; }
        [DataType("decimal(10,2)")]
        public Double OpeningDebit { get; set; }
        public string Currency { get; set; }
        public string SaleInvoiceNumber { get; set; }
        public ICollection<Payment> Payments { get; private set; }
    }
}
