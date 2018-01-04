using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Model
{
    public static class ChatConnection
    {
        public static ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
        
        public static void Publish(Chat chat)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    Queue(channel);

                    var body = Encoding.UTF8.GetBytes(chat.GetMessage());

                    QueuePublish(channel, body);
                }
            }
        }

        public static void Queue(IModel channel)
        {
            channel.QueueDeclare(queue: "batePapo",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
        }

        public static void QueuePublish(IModel channel, byte[] body)
        {
            channel.BasicPublish(exchange: "",
                                         routingKey: "batePapo",
                                         basicProperties: null,
                                         body: body);
        }

        public static void QueueConsume(IModel channel, EventingBasicConsumer consumer)
        {
            channel.BasicConsume(queue: "batePapo",
                                    autoAck: true,
                                    consumer: consumer);
        }



    }
}
