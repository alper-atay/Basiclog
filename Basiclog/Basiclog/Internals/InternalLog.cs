using System;

namespace Basiclog.Internals
{
    internal sealed class InternalLog : ILog
    {
        private InternalLog()
        {
            Message = string.Empty;
            LogType = LogType.Info;
            DateTime = DateTime.Now;
        }

        private InternalLog(string message, LogType logType)
        {
            Message = message;
            LogType = logType;
            DateTime = DateTime.Now;
        }

        private InternalLog(string message, LogType logType, DateTime dateTime)
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
            return new InternalLog(message, type);
        }

        public static ILog New(string message, LogType logType, DateTime dateTime)
        {
            return new InternalLog(message, logType, dateTime);
        }

        public static ILog NewError(string message)
        {
            return new InternalLog(message, LogType.Error);
        }

        public static ILog NewFailure(string message)
        {
            return new InternalLog(message, LogType.Failure);
        }

        public static ILog NewInfo(string message)
        {
            return new InternalLog(message, LogType.Info);
        }

        public static ILog NewSuccess(string message)
        {
            return new InternalLog(message, LogType.Success);
        }

        public static ILog NewWarning(string message)
        {
            return new InternalLog(message, LogType.Warning);
        }
    }
}