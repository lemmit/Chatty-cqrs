namespace Chatty.CQRSToolkit.Messaging
{
    internal class DummyBus : IBus
    {
        public void Publish(IMessage message)
        {
        }

        public void Response(IMessage response)
        {
        }

        public IMessageResponse Request(IMessage request)
        {
            return new MessageResponse();
        }

        private class MessageResponse : IMessageResponse
        {
        }
    }
}