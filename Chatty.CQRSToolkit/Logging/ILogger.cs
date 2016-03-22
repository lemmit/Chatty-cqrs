namespace Chatty.CQRSToolkit.Logging
{
    public interface ILogger
    {
        LoggingLevel LoggingLevel { get; }
        void Log(string message, object obj);
        void Log(string message, object obj, LoggingLevel level);
    }
}