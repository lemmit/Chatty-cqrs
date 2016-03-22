using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.Validators
{
    public interface IEventValidator<T> where T : IEvent
    {
        void Validate(T eventArg);
    }
}