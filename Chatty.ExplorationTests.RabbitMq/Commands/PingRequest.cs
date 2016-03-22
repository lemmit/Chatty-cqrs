using Bus.Test.Commands.Interfaces;

namespace Bus.Test.Commands
{
    internal class PingRequest : IPingRequest
    {
        public int BoingsCount { get; set; }
    }
}