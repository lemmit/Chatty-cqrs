using System;
using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.Validators
{
    public class LambdaCommandValidator<T> : ICommandValidator<T> where T : ICommand
    {
        private readonly Action<T> _commandValidatorAction;
        private ICommandValidator<T> _nextValidator;

        public LambdaCommandValidator(Action<T> commandValidatorAction)
        {
            _commandValidatorAction = commandValidatorAction;
        }

        public LambdaCommandValidator(Action<T> commandValidatorAction, ICommandValidator<T> )

        public void Validate(T command)
        {
            _commandValidatorAction(command);
        }
    }
}