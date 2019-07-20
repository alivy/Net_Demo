using CommonClient;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQProjectReceive
{
    public class MassTransitReceive
    {
        public MassTransitReceive()
        {
            Console.Title = "MassTransit Server";
            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://lolocalhost:15672"), hst =>
                {
                    hst.Username("guest");
                    hst.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "MassTransitTest", e =>
                {
                    e.Consumer<TestConsumerClient>();
                    e.Consumer<TestConsumerAgent>();
                });
            });

            bus.Start();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            bus.Stop();
        }
    }
}
