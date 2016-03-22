using Chatty.Contracts.Commands;
using Chatty.Contracts.Messages;

namespace Chatty.Domain.Commands
{
    internal class NewChatMessageCommand : INewChatMessageCommand
    {
        public IChatMessage ChatMessage { get; set; }
    }
}