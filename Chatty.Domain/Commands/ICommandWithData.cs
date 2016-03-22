using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.Domain.Commands
{
    public interface ICommandWithData<T> : ICommand
    {
        T Data { get; }
    }
}