using Chatty.Contracts.Messages;

namespace Chatty.Domain.Messages
{
    public class ChatMessage : IChatMessage
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}