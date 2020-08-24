using System;

namespace Basiclog
{
    internal sealed class Log : ILog
    {
        private Log()
        {
            Message = string.Empty;
            LogType = LogType.Info;
            DateTime = DateTime.Now;
        }

        private Log(string message, LogType logType)
        {
            Message = message;
            LogType = logType;
            DateTime = DateTime.Now;
        }

        private Log(string message, LogType logType, DateTime dateTime)
        {
            Message = message;
            LogType = logType;
            DateTime = dateTime;
        }

        public DateTime DateTime { get; }
        public LogType LogType { get; }
        public string Message { get; }
        public TimeSpan Time => DateTime.TimeOfDay;
        public string TimeString => Time.ToString();

        public static ILog New(string message, LogType type = LogType.Info)
        {
            return new Log(message, type);
        }

        public static ILog New(string message, LogType logType, DateTime dateTime)
        {
            return new Log(message, logType, dateTime);
        }

        public static ILog NewError(string message)
        {
            return new Log(message, LogType.Error);
        }

        public static ILog NewFailure(string message)
        {
            return new Log(message, LogType.Failure);
        }

        public static ILog NewInfo(string message)
        {
            return new Log(message, LogType.Info);
        }

        public static ILog NewSuccess(string message)
        {
            return new Log(message, LogType.Success);
        }

        public static ILog NewWarning(string message)
        {
            return new Log(message, LogType.Warning);
        }
    }
}