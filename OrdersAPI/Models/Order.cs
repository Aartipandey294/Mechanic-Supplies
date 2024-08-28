namespace OrdersAPI.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();
        public decimal TotalCost => LineItems.Sum(item => item.Total);
    }
}
