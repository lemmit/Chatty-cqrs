using Chatty.CQRSToolkit.Exceptions;
using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.Validators
{
    public class AlwaysWrongCommandValidator<T> : ICommandValidator<T>
        where T : ICommand
    {
        public void Validate(T command)
        {
            throw new CommandValidationException();
        }
    }
}