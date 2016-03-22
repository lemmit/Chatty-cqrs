using System;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Messaging;

namespace Chatty.CQRSToolkit.Emitters
{
    public class LambdaErrorEventEmitter<T, E> : AbstractErrorEventEmitter<T, E>
        where T : IMessage
        where E : IEvent
    {
        private readonly Func<T, E> _handlingFailedEmitterFunc;
        private readonly Func<T, E> _validationFailedEmitterFunc;

        public LambdaErrorEventEmitter(IBus bus, ILogger logger,
            Func<T, E> validationFailedEmitterFunc,
            Func<T, E> handlingFailerEmitterFunc)
            : base(bus, logger)
        {
            _validationFailedEmitterFunc = validationFailedEmitterFunc;
            _handlingFailedEmitterFunc = handlingFailerEmitterFunc;
        }

        public override E EmitValidationFailedEvent(T message)
        {
            return _validationFailedEmitterFunc(message);
        }

        public override E EmitHandlingFailedEvent(T message)
        {
            return _handlingFailedEmitterFunc(message);
        }
    }
}