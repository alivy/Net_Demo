using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                //简单的hello队列
                //var factory = new ConnectionFactory();
                //factory.HostName = "localhost";//RabbitMQ服务在本地运行
                //factory.UserName = "guest";//用户名
                //factory.Password = "guest";//密码

                //using (var connection = factory.CreateConnection())
                //{
                //    using (var channel = connection.CreateModel())
                //    {
                //        channel.QueueDeclare("hello", false, false, false, null);//创建一个名称为hello的消息队列
                //        string message = "Hello World"; //传递的消息内容
                //        var body = Encoding.UTF8.GetBytes(message);
                //        channel.BasicPublish("", "hello", null, body); //开始传递
                //        Console.WriteLine("已发送： {0}", message);
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
                //        string message = GetMessage(args);
                //        var properties = channel.CreateBasicProperties();
                //        properties.DeliveryMode = 2;
                //        var body = Encoding.UTF8.GetBytes(message);
                //        channel.BasicPublish("", "hello", properties, body);
                //        Console.WriteLine(" set {0}", message);
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
                //        //要保证RabbitMQ不会丢失队列，所以要做如下设置：
                //        bool durable = true;
                //        channel.QueueDeclare("task_queue", durable, false, false, null);
                //        string message = GetMessage(args);

                //        //现在保证了task_queue这个消息队列即使在RabbitMQ Server重启之后，队列也不会丢失。 然后需要保证消息也是持久化的， 这可以通过设置IBasicProperties.SetPersistent 为true来实现：
                //        var properties = channel.CreateBasicProperties();
                //        properties.Persistent = true;
                //        var body = Encoding.UTF8.GetBytes(message);
                //        channel.BasicPublish("", "task_queue", properties, body);
                //        Console.WriteLine(" set {0}", message);
                //    }
                //}
                //Console.ReadKey();
            }
            {
                MassTransitSend massTransitSend = new MassTransitSend();
            }
        }


        private static string GetMessage(string[] args)
        {

            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
