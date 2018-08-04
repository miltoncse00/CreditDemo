using Newtonsoft.Json;
using System;

namespace CreditDemo.Common
{
    public class PaymentModel {
        [JsonProperty("payment_date")]
        public DateTime PaymentDate { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("payment_amount")]
        public decimal PaymentAmount { get; set; }
    }
}
