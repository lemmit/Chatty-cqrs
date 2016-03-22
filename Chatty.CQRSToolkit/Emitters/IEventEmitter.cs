using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Messaging;

namespace Chatty.CQRSToolkit.Emitters
{
    public interface IEventEmitter<T, E>
        where T : IMessage
        where E : IEvent
    {
        E Emit(T message);
    }
}