namespace PartsAPI.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
