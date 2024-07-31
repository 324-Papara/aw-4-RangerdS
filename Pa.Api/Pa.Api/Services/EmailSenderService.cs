using Hangfire;
using Microsoft.Extensions.Options;
using Pa.Base.Mail;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace Pa.Api.Services
{
    public class EmailSenderService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly SmtpSettings _smtpSettings;

        public EmailSenderService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "emailQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        [AutomaticRetry(Attempts = 3)]
        public void ProcessEmailQueue()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailMessage = JsonSerializer.Deserialize<EmailMessage>(message);

                SendEmail(emailMessage);
            };

            _channel.BasicConsume(queue: "emailQueue", autoAck: true, consumer: consumer);
        }

        private void SendEmail(EmailMessage emailMessage)
        {
            var smtpClient = new SmtpClient(_smtpSettings.Host)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail),
                Subject = emailMessage.Subject,
                Body = emailMessage.Body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(emailMessage.To);

            smtpClient.Send(mailMessage);
        }
    }
}