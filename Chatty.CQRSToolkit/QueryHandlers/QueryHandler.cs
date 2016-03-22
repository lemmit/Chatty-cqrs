using System;
using System.Threading.Tasks;
using Chatty.CQRSToolkit.Emitters;
using Chatty.CQRSToolkit.Exceptions;
using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Messaging;
using Chatty.CQRSToolkit.Validators;

namespace Chatty.CQRSToolkit.QueryHandlers
{
    public class QueryHandler<T, R, E, F>
        : IQueryHandler<T, R>
        where T : IQuery
        where R : IQueryResponse
        where E : IEvent
        where F : IEvent
    {
        private readonly IBus _bus;
        private readonly IErrorEventEmitter<T, E, F> _errorEventEmitter;
        private readonly IQueryHandler<T, R> _handler;
        private readonly ILogger _logger;
        private readonly IQueryValidator<T> _queryValidator;

        protected QueryHandler(IBus bus,
            IQueryValidator<T> queryValidator,
            IErrorEventEmitter<T, E, F> errorEventEmitter,
            IQueryHandler<T, R> handler,
            ILogger logger)
        {
            _bus = bus;
            _queryValidator = queryValidator;
            _errorEventEmitter = errorEventEmitter;
            _logger = logger;
            _handler = handler;
        }

        public virtual R Handle(T query)
        {
            var response = default(R);
            try
            {
                _queryValidator.Validate(query);
                response = Task.Run(() => _handler.Handle(query)).Result;
                _bus.Response(response);
            }
            catch (QueryValidationException e)
            {
                _errorEventEmitter.EmitValidationFailed(query);
            }
            catch (QueryHandlerException e)
            {
                _errorEventEmitter.EmitHandlingFailed(query);
            }
            catch (Exception e)
            {
                _logger.Log("Exception while handling query[" + e.GetType() + "]: " + e.StackTrace, query);
                throw new QueryHandlerException();
            }
            return response;
        }
    }
}