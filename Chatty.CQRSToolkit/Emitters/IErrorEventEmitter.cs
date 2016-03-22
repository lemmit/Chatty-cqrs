using Chatty.CQRSToolkit.Interfaces;
using Chatty.CQRSToolkit.Messaging;

namespace Chatty.CQRSToolkit.Emitters
{
    public interface IErrorEventEmitter<T, E, R>
        where T : IMessage
        where E : IEvent
        where R : IEvent
    {
        E EmitValidationFailed(T message);
        R EmitHandlingFailed(T message);
    }
}