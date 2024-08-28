using System.Text.Json.Serialization;

namespace OrdersAPI.Models
{
    public class LineItem
    {
        public int PartId { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Quantity * UnitPrice;

        [JsonIgnore]
        public decimal UnitPrice { get; set; }
    }
}
