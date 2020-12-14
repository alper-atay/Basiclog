using System;

namespace Basiclog.Internals
{
    internal class InternalValuedLog : IValuedLog
    {
        private InternalValuedLog(object value)
        {
            Value = value;
            Message = string.Empty;
            LogType = LogType.Info;
            DateTime = DateTime.Now;
        }

        private InternalValuedLog(object value, ILog log)
        {
            Value = value;
            Message = log.Message;
            LogType = log.LogType;
            DateTime = log.DateTime;
        }

        private InternalValuedLog(object value, string message, LogType logType = LogType.Info)
        {
            Value = value;
            Message = message;
            LogType = logType;
            DateTime = DateTime.Now;
        }

        private InternalValuedLog(object value, string message, LogType logType, DateTime dateTime)
        {
            Value = value;
            Message = message;
            LogType = logType;
            DateTime = dateTime;
        }

        public DateTime DateTime { get; }

        public LogType LogType { get; }

        public string Message { get; }

        public TimeSpan Time { get; }

        public string TimeString { get; }

        public object Value { get; }

        public static IValuedLog New(object value)
        {
            return new InternalValuedLog(value);
        }

        public static IValuedLog New(object value, ILog log)
        {
            return new InternalValuedLog(value, log);
        }

        public static IValuedLog New(object value, string message, LogType type = LogType.Info)
        {
            return new InternalValuedLog(value, message, type);
        }

        public static IValuedLog New(object value, string message, LogType logType, DateTime dateTime)
        {
            return new InternalValuedLog(value, message, logType, dateTime);
        }

        public static IValuedLog NewError(object value, string message)
        {
            return new InternalValuedLog(value, message, LogType.Error);
        }

        public static IValuedLog NewFailure(object value, string message)
        {
            return new InternalValuedLog(value, message, LogType.Failure);
        }

        public static IValuedLog NewInfo(object value, string message)
        {
            return new InternalValuedLog(value, message, LogType.Info);
        }

        public static IValuedLog NewSuccess(object value, string message)
        {
            return new InternalValuedLog(value, message, LogType.Success);
        }

        public static IValuedLog NewWarning(object value, string message)
        {
            return new InternalValuedLog(value, message, LogType.Warning);
        }
    }

    internal class InternalValuedLog<T> : IValuedLog<T>
    {
        private InternalValuedLog(T value)
        {
            Value = value;
            Message = string.Empty;
            LogType = LogType.Info;
            DateTime = DateTime.Now;
        }

        private InternalValuedLog(T value, ILog log)
        {
            Value = value;
            Message = log.Message;
            LogType = log.LogType;
            DateTime = log.DateTime;
        }

        private InternalValuedLog(T value, string message, LogType logType = LogType.Info)
        {
            Value = value;
            Message = message;
            LogType = logType;
            DateTime = DateTime.Now;
        }

        private InternalValuedLog(T value, string message, LogType logType, DateTime dateTime)
        {
            Value = value;
            Message = message;
            LogType = logType;
            DateTime = dateTime;
        }

        public DateTime DateTime { get; }

        public LogType LogType { get; }

        public string Message { get; }

        public TimeSpan Time { get; }

        public string TimeString { get; }

        public T Value { get; }

        object IValuedLog.Value => Value;

        public static IValuedLog<T> New(T value)
        {
            return new InternalValuedLog<T>(value);
        }

        public static IValuedLog<T> New(T value, ILog log)
        {
            return new InternalValuedLog<T>(value, log);
        }

        public static IValuedLog<T> New(T value, string message, LogType type = LogType.Info)
        {
            return new InternalValuedLog<T>(value, message, type);
        }

        public static IValuedLog<T> New(T value, string message, LogType logType, DateTime dateTime)
        {
            return new InternalValuedLog<T>(value, message, logType, dateTime);
        }

        public static IValuedLog<T> NewError(T value, string message)
        {
            return new InternalValuedLog<T>(value, message, LogType.Error);
        }

        public static IValuedLog<T> NewFailure(T value, string message)
        {
            return new InternalValuedLog<T>(value, message, LogType.Failure);
        }

        public static IValuedLog<T> NewInfo(T value, string message)
        {
            return new InternalValuedLog<T>(value, message, LogType.Info);
        }

        public static IValuedLog<T> NewSuccess(T value, string message)
        {
            return new InternalValuedLog<T>(value, message, LogType.Success);
        }

        public static IValuedLog<T> NewWarning(T value, string message)
        {
            return new InternalValuedLog<T>(value, message, LogType.Warning);
        }
    }
}