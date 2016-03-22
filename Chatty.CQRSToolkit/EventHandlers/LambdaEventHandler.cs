using System;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Validators;

namespace Chatty.CQRSToolkit.EventHandlers
{
    public class LambdaEventHandler<T> : AbstractEventHandler<T>
        where T : IEvent
    {
        private readonly Action<T> _eventHandlerAction;

        public LambdaEventHandler(IEventValidator<T> eventValidator, ILogger logger, Action<T> eventHandlerAction)
            : base(eventValidator, logger)
        {
            _eventHandlerAction = eventHandlerAction;
        }

        public override void HandleEvent(T eventArg)
        {
            _eventHandlerAction(eventArg);
        }
    }
}