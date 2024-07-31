using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Pa.Api.Services
{
    public class EmailQueueService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public EmailQueueService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "emailQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void EnqueueEmail(EmailMessage emailMessage)
        {
            var message = JsonSerializer.Serialize(emailMessage);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: "emailQueue", basicProperties: null, body: body);
        }
    }

    public class EmailMessage
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
