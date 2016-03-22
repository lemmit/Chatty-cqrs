using System;
using System.Threading.Tasks;
using Chatty.CQRSToolkit.Emitters;
using Chatty.CQRSToolkit.Exceptions;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Validators;

namespace Chatty.CQRSToolkit.CommandHandlers
{
    public class CommandHandler<T, E, F, R> : ICommandHandler<T>
        where T : ICommand
        where E : IEvent
        where F : IEvent
        where R : IEvent
    {
        private readonly IErrorEventEmitter<T, E, R> _errorEventEmitter;
        private readonly IEventEmitter<T, F> _eventEmitter;
        private readonly ICommandHandler<T> _handler;
        private readonly ILogger _logger;
        private readonly ICommandValidator<T> _validator;

        protected CommandHandler(ICommandValidator<T> commandValidator,
            IEventEmitter<T, F> eventEmitter,
            IErrorEventEmitter<T, E, R> errorEventEmitter,
            ICommandHandler<T> handler,
            ILogger logger)
        {
            _validator = commandValidator;
            _eventEmitter = eventEmitter;
            _errorEventEmitter = errorEventEmitter;
            _handler = handler;
            _logger = logger;
        }

        public async void Handle(T command)
        {
            try
            {
                _validator.Validate(command);
                await Task.Run(() => _handler.Handle(command));
                _eventEmitter.Emit(command);
            }
            catch (CommandValidationException e)
            {
                _errorEventEmitter.EmitValidationFailed(command);
            }
            catch (CommandHandlerException e)
            {
                _errorEventEmitter.EmitHandlingFailed(command);
            }
            catch (Exception e)
            {
                _logger.Log("Exception while handling command[" + e.GetType() + "]: "
                            + e.StackTrace, command);
                throw new CommandHandlerException();
            }
        }
    }
}