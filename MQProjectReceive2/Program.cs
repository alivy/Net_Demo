using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MQProjectReceive2
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var factory = new ConnectionFactory();
                factory.HostName = "localhost";
                factory.UserName = "guest";//用户名
                factory.Password = "guest";//密码
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        bool durable = true;
                        channel.QueueDeclare("task_queue", durable, false, false, null);
                        channel.BasicQos(0, 1, false);

#pragma warning disable CS0618 // 类型或成员已过时
                        var consumer = new QueueingBasicConsumer(channel);
#pragma warning restore CS0618 // 类型或成员已过时
                        channel.BasicConsume("task_queue", false, consumer);

                        while (true)
                        {
                            var ea = consumer.Queue.Dequeue();

                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);

                            int dots = message.Split('.').Length - 1;
                            Thread.Sleep(dots * 1000);

                            Console.WriteLine("Received {0}", message);
                            Console.WriteLine("Done");

                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                    }
                }
            }
        }
    }
}
