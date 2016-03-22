using Chatty.Contracts.Messages;
using Chatty.CQRSToolkit.Interfaces;

namespace Chatty.Contracts.Commands
{
    public interface INewChatMessageCommand : ICommand
    {
        IChatMessage ChatMessage { get; set; }
    }
}