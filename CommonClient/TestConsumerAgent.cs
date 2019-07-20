using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClient
{
    public class TestConsumerAgent : IConsumer<Agent>
    {
        public async Task Consume(ConsumeContext<Agent> context)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync($"Receive message: {context.Message.AgentCode}, {context.Message.AgentName}, {context.Message.AgentRole}");
            Console.ResetColor();
        }
    }

    public class Agent
    {
        public int AgentCode { get; set; }
        public string AgentName { get; set; }
        public string AgentRole { get; set; }
        public string Message { get; set; }
    }

}
