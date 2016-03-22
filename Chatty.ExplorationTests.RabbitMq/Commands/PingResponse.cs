using Bus.Test.Commands.Interfaces;

namespace Bus.Test.Commands
{
    internal class PingResponse : IPingResponse
    {
        public int BoingsCount { get; set; }
    }
}