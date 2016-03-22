namespace Chatty.CQRSToolkit.Logging
{
    internal class DoubleLogger : ILogger
    {
        private readonly ILogger _firstLogger;
        private readonly ILogger _secondLogger;

        public DoubleLogger(ILogger firstLogger, ILogger secondLogger)
        {
            _firstLogger = firstLogger;
            _secondLogger = secondLogger;
        }


        public void Log(string message, object obj)
        {
            _firstLogger.Log(message, obj);
            _secondLogger.Log(message, obj);
        }

        public void Log(string message, object obj, LoggingLevel level)
        {
            _firstLogger.Log(message, obj);
            _secondLogger.Log(message, obj);
        }

        public LoggingLevel LoggingLevel
        {
            get
            {
                return _firstLogger.LoggingLevel > _secondLogger.LoggingLevel
                    ? _firstLogger.LoggingLevel
                    : _secondLogger.LoggingLevel;
            }
        }
    }
}