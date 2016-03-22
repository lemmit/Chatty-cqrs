using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.EventHandlers
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T eventArg);
    }
}