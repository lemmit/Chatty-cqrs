using Chatty.CQRSToolkit.Logging;

namespace Chatty.CQRSToolkit.Messaging
{
    internal class LoggingBusProxy : IBus
    {
        private static ILogger _logger;
        private IBus _bus;

        public LoggingBusProxy(IBus bus, ILogger logger)
        {
            if (bus == null)
            {
                bus = new DummyBus();
            }
        }

        public void Publish(IMessage message)
        {
            _logger.Log("Publish message send: ", message);
            _bus.Publish(message);
        }

        public void Response(IMessage response)
        {
            _logger.Log("Response message send: ", response);
            _bus.Response(response);
        }

        public IMessageResponse Request(IMessage request)
        {
            _logger.Log("Request message send: ", request);
            return _bus.Request(request);
        }
    }
}