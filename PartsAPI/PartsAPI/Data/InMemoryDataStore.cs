using PartsAPI.Models;

namespace PartsAPI.Data
{
    public class InMemoryDataStore
    {
        public List<Part> Parts { get; set; }

        public InMemoryDataStore()
        {
            
            Parts = new List<Part>
        {
            new Part { Id = 1, Description = "Wire", Price = 5.99m, Quantity = 5 },
            new Part { Id = 2, Description = "Brake Fluid", Price = 4.90m, Quantity = 20 },
            new Part { Id = 3, Description = "Engine Oil", Price = 15.00m, Quantity = 12 }
        };
        }
    }
}
