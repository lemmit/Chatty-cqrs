using Chatty.CQRSToolkit.Exceptions;

namespace Chatty.CQRSToolkit.Messaging
{
    internal class BusManager
    {
        private static IBus _bus;

        public static void RegisterLogger(IBus bus)
        {
            _bus = bus;
        }

        public static IBus GetLogger()
        {
            if (_bus == null)
            {
                throw new BusNotFoundException();
            }
            return _bus;
        }
    }
}