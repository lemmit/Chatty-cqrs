namespace Chatty.CQRSToolkit.Messaging
{
    public interface IBus
    {
        void Publish(IMessage message);
        void Response(IMessage response);
        IMessageResponse Request(IMessage request);
    }
}