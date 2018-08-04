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
        [JsonProperty("payment_amount")]
        public decimal PaymentAmount { get; set; }
    }
}
