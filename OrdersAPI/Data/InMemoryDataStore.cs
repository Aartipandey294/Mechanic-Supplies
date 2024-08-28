using OrdersAPI.Models;

namespace OrdersAPI.Data
{
    public class InMemoryDataStore
    {
        public List<Order> Orders { get; set; }

        public InMemoryDataStore()
        {
            Orders = new List<Order>();
        }
    }
}
