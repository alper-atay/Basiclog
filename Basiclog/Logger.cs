using System;

namespace Basiclog
{
    public static class Logger
    {
        public static ILog NewLog(string message, LogType logType = LogType.Info, DateTime? dateTime = null)
        {
            if (dateTime.HasValue)
            {
                return Log.New(message, logType, dateTime.Value);
            }
            else
            {
                return Log.New(message, logType);
            }
        }

        public static ILogbook NewLogbook()
        {
            return new Logbook();
        }

        public static IObservableLogbook NewObservableLogbook()
        {
            return new ObservableLogbook();
        }
    }
}