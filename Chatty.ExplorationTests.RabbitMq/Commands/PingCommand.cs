using Bus.Test.Commands.Interfaces;

namespace Bus.Test.Commands
{
    internal class PingCommand : IPingCommand
    {
        public int BoingsCount { get; set; }
    }
}