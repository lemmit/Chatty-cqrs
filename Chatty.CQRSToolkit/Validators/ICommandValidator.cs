using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.Validators
{
    public interface ICommandValidator<T> where T : ICommand
    {
        void Validate(T command);
    }
}