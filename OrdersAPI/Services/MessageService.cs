using RabbitMQ.Client;
using System.Text;

namespace OrdersAPI.Services
{
    public class MessageService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "ordersQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: "ordersQueue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}
