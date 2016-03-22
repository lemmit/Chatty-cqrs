using System.Threading.Tasks;
using Bus.Test.Commands.Interfaces;
using MassTransit;

namespace Bus.Test
{
    public class PingCommandConsumer : IConsumer<IPingCommand>
    {
        public PingCommandConsumer(TestConnectionToBus test)
        {
            Test = test;
        }

        public TestConnectionToBus Test { get; set; }

        public Task Consume(ConsumeContext<IPingCommand> context)
        {
            //Console.WriteLine("TXT: " + context.Message);
            Test.MessageReceived();
            return Task.FromResult(0);
        }
    }
}