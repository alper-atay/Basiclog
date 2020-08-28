using Basiclog.Internals;
using System;

namespace Basiclog
{
    public static class Logger
    {
        public static ILog NewLog(string message, LogType logType = LogType.Info, DateTime? dateTime = null)
        {
            if (dateTime.HasValue)
            {
                return InternalLog.New(message, logType, dateTime.Value);
            }
            else
            {
                return InternalLog.New(message, logType);
            }
        }

        public static ILogbook NewLogbook()
        {
            return new InternalLogbook();
        }

        public static IObservableLogbook NewObservableLogbook()
        {
            return new InternalObservableLogbook();
        }
    }
}