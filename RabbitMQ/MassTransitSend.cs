using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RabbitMQ
{
    public class MassTransitSend
    {
        public MassTransitSend()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://lolocalhost:15672"), hst =>
                {
                    hst.Username("guest");
                    hst.Password("guest");
                });
            });

            var uri = new Uri("rabbitmq://lolocalhost:15672");
            var message = Console.ReadLine();
            while (message != null)
            {
                Task.Run(() => SendCommand(bus, uri, message)).Wait();
                message = Console.ReadLine();
            }

            Console.ReadKey();
        }

        private static async void SendCommand(IBusControl bus, Uri sendToUri, string message)
        {
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            var command = new CommonClient.Client()
            {
                Id = 100001,
                Name = "Edison Zhou",
                Birthdate = DateTime.Now.AddYears(-18),
                Message = message
            };
            await bus.Publish(command);
            await endPoint.Send(command);
            Console.WriteLine($"You Sended : Id = {command.Id}, Name = {command.Name}, Message = {command.Message}");
        }
    }
}
