using System;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Messaging;

namespace Chatty.CQRSToolkit.Emitters
{
    public class LambdaEventEmitter<T, E> : AbstractEventEmitter<T, E>
        where T : ICommand
        where E : IEvent
    {
        private readonly Func<T, E> _eventEmitterAction;

        public LambdaEventEmitter(IBus bus, ILogger logger,
            Func<T, E> eventEmitterAction)
            : base(bus, logger)
        {
            _eventEmitterAction = eventEmitterAction;
        }

        public override E EmitEvent(T command)
        {
            return _eventEmitterAction(command);
        }
    }
}