using Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
namespace Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User(1, "Player 2");
            var chat = new Chat(user);

            using (var connection = ChatConnection.factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                ChatConnection.Queue(channel);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(message);
                };

                ChatConnection.QueueConsume(channel, consumer);


                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }

        }
    }
}