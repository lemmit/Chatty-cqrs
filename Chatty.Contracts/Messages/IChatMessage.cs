namespace Chatty.Contracts.Messages
{
    public interface IChatMessage
    {
        string Id { get; }
        string From { get; }
        string To { get; }
    }
}