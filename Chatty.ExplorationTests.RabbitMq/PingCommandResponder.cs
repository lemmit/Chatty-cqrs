using System.Threading.Tasks;
using Bus.Test.Commands;
using Bus.Test.Commands.Interfaces;
using MassTransit;

namespace Bus.Test
{
    public class PingCommandResponder : IConsumer<IPingRequest>
    {
        public Task Consume(ConsumeContext<IPingRequest> context)
        {
            //Console.WriteLine("TXT: " + context.Message);
            context.Respond(new PingResponse
            {
                BoingsCount = context.Message.BoingsCount + 1
            });
            return Task.FromResult(0);
        }
    }
}