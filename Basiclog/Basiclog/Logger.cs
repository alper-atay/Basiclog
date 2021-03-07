using Basiclog.Internals;
using System;
using System.IO;

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

        public static void WriteToFile(this IReadOnlyLogbook logs, string filePath)
        {
            var fileStream = File.Open(filePath, FileMode.OpenOrCreate);

            StringWriter stringWriter = new StringWriter();

        }

        public static ILogbook NewLogbook()
        {
            return new InternalLogbook();
        }

        public static IObservableLogbook NewObservableLogbook()
        {
            return new InternalObservableLogbook();
        }

        public static IValuedLog NewValuedLog(object value, string message, LogType logType = LogType.Info, DateTime? dateTime = null)
        {
            if (dateTime.HasValue)
            {
                return InternalValuedLog.New(value, message, logType, dateTime.Value);
            }
            else
            {
                return InternalValuedLog.New(value, message, logType);
            }
        }

        public static IValuedLog NewValuedLog<T>(T value, string message, LogType logType = LogType.Info, DateTime? dateTime = null)
        {
            if (dateTime.HasValue)
            {
                return InternalValuedLog<T>.New(value, message, logType, dateTime.Value);
            }
            else
            {
                return InternalValuedLog<T>.New(value, message, logType);
            }
        }

        public static IValuedLogbook NewValuedLogbook()
        {
            return new InternalValuedLogbook();
        }

        public static IValuedLogbook<T> NewValuedLogbook<T>()
        {
            return new InternalValuedLogbook<T>();
        }
    }
}