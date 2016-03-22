using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.Validators
{
    public class AlwaysFineCommandValidator<T> : ICommandValidator<T>
        where T : ICommand
    {
        public void Validate(T command)
        {
        }
    }
}