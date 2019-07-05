using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SuS.Common;

namespace SuS.Infrastructure
{
    public class RabbitMqSender : IRabbitMqSender
    {
     
        private static string _host { get; set; }
       private static ConnectionFactory _factory { get; set; }


       public RabbitMqSender(IConfigurationService configurationService)
       {
           _factory = new ConnectionFactory();
           _factory.HostName = configurationService.GetUrl("RabbitMQ-Service", false);
           _factory.UserName = "rabbitmquser";
           _factory.Password = "DEBmbwkSrzy9D1T9cJfa";
       }

       public bool PushMessage(string queue, string message, IDictionary<string, object> arguments)
       {
           using (var connection = _factory.CreateConnection())

           using (var channel = connection.CreateModel())
           {
               channel.QueueDeclare(queue: queue,
                   durable: true,
                   exclusive: false,
                   autoDelete: false,
                   arguments: null);

               var body = Encoding.UTF8.GetBytes(message);

               channel.BasicPublish(exchange: "",
                   routingKey: queue,
                   basicProperties: null,
                   body: body);
           }
           return true;
       }

       public void ReadMessage()
       {
           using (var connection = _factory.CreateConnection())
           {
               using (var channel = connection.CreateModel())
               {
                   channel.QueueDeclare(queue: "draft",
                       durable: false,
                       exclusive: false,
                       autoDelete: false,
                       arguments: null);

                   var consumer = new EventingBasicConsumer(channel);
                   consumer.Received += (model, ea) =>
                   {
                       var body = ea.Body;
                       var message = Encoding.UTF8.GetString(body);
                       Console.WriteLine(" [x] Received {0}", message);
                   };
                   channel.BasicConsume(queue: "draft",
                       autoAck: true,
                       consumer: consumer);

               }
           }


       }
        
    }
}