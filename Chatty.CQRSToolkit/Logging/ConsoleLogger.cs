using System;

namespace Chatty.CQRSToolkit.Logging
{
    internal class ConsoleLogger : ILogger
    {
        public ConsoleLogger(LoggingLevel loggingLevel)
        {
            LoggingLevel = loggingLevel;
        }

        public LoggingLevel LoggingLevel { get; }

        public void Log(string message, object obj)
        {
            Console.WriteLine(message + obj);
        }

        public void Log(string message, object obj, LoggingLevel level)
        {
            if (LoggingLevel >= level)
                Console.WriteLine(message + obj);
        }
    }
}