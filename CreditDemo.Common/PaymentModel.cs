using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CreditDemo.Common
{
    public class PaymentModel {
        [Required]
        [JsonProperty("payment_date")]
        public DateTime PaymentDate { get; set; }
        [JsonProperty("description")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(0, 99999999.99, ErrorMessage = "Amount must be numeric, greater than 0, and smaller than 100000000")]
        [JsonProperty("payment_amount")]
        public decimal PaymentAmount { get; set; }
    }
}
