using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditDemo.Common
{
    public class SaleModel
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName ="customer_id")]
        public string CustomerId { get; set; }
        [JsonProperty(PropertyName ="timestamp")]
        public DateTime TimeStamp { get; set; }
        [JsonProperty(PropertyName ="location_name")]
        public string LocationName { get; set; }
        [JsonProperty(PropertyName ="operator_name")]
        public string OperatorName { get; set; }
        [JsonProperty(PropertyName ="opening_debt")]
        public decimal OpeningDebit { get; set; }
        [JsonProperty(PropertyName ="currency")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName ="sale_invoice_number")]
        public string SaleInvoiceNumber { get; set; }
        [JsonProperty(PropertyName = "payments")]
        public IList<PaymentModel> Payments { get; set; }


    }
}
