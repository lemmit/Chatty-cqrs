using System;
using System.Threading.Tasks;
using Chatty.CQRSToolkit.Exceptions;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Validators;

namespace Chatty.CQRSToolkit.EventHandlers
{
    public class EventHandler<T> : IEventHandler<T>
        where T : IEvent
    {
        private readonly IEventValidator<T> _eventValidator;
        private readonly ILogger _logger;

        public EventHandler(IEventValidator<T> eventValidator,
            ILogger logger)
        {
            _eventValidator = eventValidator;
            _logger = logger;
        }

        public async Task Handle(T eventArg)
        {
            try
            {
                _eventValidator.Validate(eventArg);
                await Task.Run(() => HandleEvent(eventArg));
            }
            catch (EventValidationException e)
            {
            }
            catch (EventHandlingException e)
            {
            }
            catch (Exception e)
            {
                _logger.Log("Exception while handling event[" + e.GetType() + "]: "
                            + e.StackTrace, eventArg);
                throw new EventHandlerException();
            }
        }

        public abstract void HandleEvent(T eventArg);
    }
}