using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.CQRSToolkit.CommandHandlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}