using System;
using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.CommandHandlers
{
    public class LambdaCommandHandler<T> : ICommandHandler<T>
        where T : ICommand
    {
        private readonly Action<T> _commandHandlerAction;

        public LambdaCommandHandler(Action<T> commandHandlerAction)
        {
            _commandHandlerAction = commandHandlerAction;
        }

        public void Handle(T command)
        {
            _commandHandlerAction(command);
        }
    }
}