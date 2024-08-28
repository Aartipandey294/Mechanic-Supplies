using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Data;
using OrdersAPI.Models;
using OrdersAPI.Services;
using System.Text.Json;

namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly InMemoryDataStore _dataStore;
        private readonly MessageService _rabbitMQService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(InMemoryDataStore dataStore, MessageService rabbitMQService, ILogger<OrdersController> logger)
        {
            _dataStore = dataStore;
            _rabbitMQService = rabbitMQService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] List<LineItem> lineItems)
        {
            var order = new Order
            {
                OrderNumber = _dataStore.Orders.Count + 1,
                LineItems = lineItems
            };

            foreach (var item in order.LineItems)
            {
                var partPrice = GetPartPrice(item.PartId);
                if (partPrice == null)
                {
                    _logger.LogWarning($"Part with Id {item.PartId} not found.");
                    return BadRequest($"Part with Id {item.PartId} not found.");
                }

                item.UnitPrice = partPrice.Value;
            }

            _dataStore.Orders.Add(order);

            var orderMessage = JsonSerializer.Serialize(order);
            _rabbitMQService.SendMessage(orderMessage);

            _logger.LogInformation($"Order {order.OrderNumber} placed successfully.");
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_dataStore.Orders);
        }

        // This method simulates a call to the PartsService to get the price of a part.
        private decimal? GetPartPrice(int partId)
        {
            // This would be an API call in a real microservices architecture.
            return partId switch
            {
                1 => 5.99m,
                2 => 4.90m,
                3 => 15.00m,
                _ => null
            };
        }
    }
}
