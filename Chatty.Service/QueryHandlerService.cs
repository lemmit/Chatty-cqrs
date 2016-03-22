using System;
using System.Timers;

namespace Chatty.Service
{
    public class QueryHandlerService
    {
        private readonly Timer _timer;

        public QueryHandlerService()
        {
            _timer = new Timer(1000) {AutoReset = true};
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
        }

        public bool Start()
        {
            _timer.Start();
            return true;
        }

        public bool Stop()
        {
            _timer.Stop();
            return true;
        }
    }
}