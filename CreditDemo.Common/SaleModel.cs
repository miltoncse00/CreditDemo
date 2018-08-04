using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CreditDemo.Common
{
    public class SaleModel
    {
        [Required]
        [MaxLength(12)]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        [MaxLength(12)]
        [JsonProperty(PropertyName = "customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime TimeStamp { get; set; }
        [MaxLength(500)]
        [JsonProperty(PropertyName = "location_name")]
        public string LocationName { get; set; }
        [MaxLength(500)]
        [JsonProperty(PropertyName = "operator_name")]
        [Required]
        public string OperatorName { get; set; }
        [JsonProperty(PropertyName = "opening_debt")]
        public decimal OpeningDebit { get; set; }
        [JsonProperty(PropertyName = "currency")]
        [MaxLength(50)]
        public string Currency { get; set; }
        [Required]
        [MaxLength(50)]
        [JsonProperty(PropertyName = "sale_invoice_number")]
        public string SaleInvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "payments")]
        [Required]
        public List<PaymentModel> Payments { get; set; }


    }
}
