using System;
using Chatty.CQRSToolkit.Exceptions;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Messaging;

namespace Chatty.CQRSToolkit.Emitters
{
    public class ErrorEventEmitter<T, E, R> : IErrorEventEmitter<T, E, R>
        where T : IMessage
        where E : IEvent
        where R : IEvent
    {
        private readonly IBus _bus;
        private readonly IEventEmitter<T, R> _handlingFailedEventEmitter;
        private readonly ILogger _logger;
        private readonly IEventEmitter<T, E> _validationFailedEventEmitter;

        protected ErrorEventEmitter(IBus bus, ILogger logger, IEventEmitter<T, E> validationFailedEventEmitter,
            IEventEmitter<T, R> handlingFailedEventEmitter)
        {
            _bus = bus;
            _logger = logger;
            _validationFailedEventEmitter = validationFailedEventEmitter;
            _handlingFailedEventEmitter = handlingFailedEventEmitter;
        }

        public E EmitValidationFailed(T message)
        {
            var eventToEmit = default(E);
            try
            {
                eventToEmit = _validationFailedEventEmitter.Emit(message);
                _bus.Publish(eventToEmit);
            }
            catch (Exception e)
            {
                throw new EmitterException();
            }
            return eventToEmit;
        }

        public R EmitHandlingFailed(T message)
        {
            var eventToEmit = default(R);
            try
            {
                eventToEmit = _handlingFailedEventEmitter.Emit(message);
                _bus.Publish(eventToEmit);
            }
            catch (Exception e)
            {
                throw new EmitterException();
            }
            return eventToEmit;
        }
    }
}