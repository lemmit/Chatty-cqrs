using System;
using Chatty.CQRSToolkit.Exceptions;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Messaging;

namespace Chatty.CQRSToolkit.Emitters
{
    public class EventEmitter<T, E> : IEventEmitter<T, E>
        where T : ICommand
        where E : IEvent
    {
        private readonly IBus _bus;
        private readonly IEventEmitter<T, E> _eventEmitter;
        private readonly ILogger _logger;

        protected EventEmitter(IBus bus, ILogger logger, IEventEmitter<T, E> eventEmitter)
        {
            _bus = bus;
            _logger = logger;
            _eventEmitter = eventEmitter;
        }

        public E Emit(T command)
        {
            var eventToEmit = default(E);
            try
            {
                eventToEmit = _eventEmitter.Emit(command);
                _bus.Publish(eventToEmit);
            }
            catch (Exception e)
            {
                _logger.Log("Exception while emitting event: ", e.StackTrace);
                throw new EmitterException();
            }
            return eventToEmit;
        }
    }
}