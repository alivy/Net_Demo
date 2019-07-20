using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MQProjectReceive
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                //var factory = new ConnectionFactory();
                //factory.HostName = "localhost";
                //factory.UserName = "guest";
                //factory.Password = "guest";

                //using (var connection = factory.CreateConnection())
                //{
                //    using (var channel = connection.CreateModel())
                //    {
                //        channel.QueueDeclare("hello", false, false, false, null);

                //        var consumer = new EventingBasicConsumer(channel);
                //        channel.BasicConsume("hello", false, consumer);
                //        consumer.Received += (model, ea) =>
                //        {
                //            var body = ea.Body;
                //            var message = Encoding.UTF8.GetString(body);
                //            Console.WriteLine("已接收： {0}", message);
                //        };
                //        Console.ReadLine();
                //    }
                //}
            }
            {
                //var factory = new ConnectionFactory();
                //factory.HostName = "localhost";
                //factory.UserName = "guest";//用户名
                //factory.Password = "guest";//密码

                //using (var connection = factory.CreateConnection())
                //{
                //    using (var channel = connection.CreateModel())
                //    {
                //        channel.QueueDeclare("hello", false, false, false, null);

                //        var consumer = new QueueingBasicConsumer(channel);
                //        channel.BasicConsume("hello", true, consumer);

                //        while (true)
                //        {
                //            var ea = consumer.Queue.Dequeue();

                //            var body = ea.Body;
                //            var message = Encoding.UTF8.GetString(body);

                //            int dots = message.Split('.').Length - 1;
                //            Thread.Sleep(dots * 1000);
                //            Console.WriteLine("Received {0}", message);
                //            Console.WriteLine("Done");
                //        }
                //    }
                //}
            }
            {
                //var factory = new ConnectionFactory();
                //factory.HostName = "localhost";
                //factory.UserName = "guest";//用户名
                //factory.Password = "guest";//密码

                //using (var connection = factory.CreateConnection())
                //{
                //    using (var channel = connection.CreateModel())
                //    {
                //        bool durable = true;
                //        channel.QueueDeclare("task_queue", durable, false, false, null);
                //        //公平分发
                //        //为了改变这一状态，我们可以使用basicQos方法，设置perfetchCount = 1 。
                //        //这样就告诉RabbitMQ 不要在同一时间给一个工作者发送多于1个的消息，或者换句话说。
                //        //在一个工作者还在处理消息，并且没有响应消息之前，不要给他分发新的消息。
                //        //相反，将这条新的消息发送给下一个不那么忙碌的工作者
                //        channel.BasicQos(0, 1, false);

                //        var consumer = new QueueingBasicConsumer(channel);
                //        channel.BasicConsume("task_queue", false, consumer);

                //        while (true)
                //        {
                //            var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                //            var body = ea.Body;
                //            var message = Encoding.UTF8.GetString(body);

                //            int dots = message.Split('.').Length - 1;
                //            Thread.Sleep(dots * 1000);

                //            Console.WriteLine("Received {0}", message);
                //            Console.WriteLine("Done");

                //            channel.BasicAck(ea.DeliveryTag, false);
                //        }
                //    }
            }
            {
                MassTransitReceive massTransitReceive = new MassTransitReceive();
            }
        }
    }
}
