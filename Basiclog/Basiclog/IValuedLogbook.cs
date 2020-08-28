using System;
using System.Collections.Generic;

namespace Basiclog
{
    public interface IValuedLogbook : ILogbook, IReadOnlyValuedLogbook
    {
        void Add(IValuedLog valuedLog);

        void Add(object value, string message, LogType logType);

        void AddRange(IEnumerable<IValuedLog> valuedLogs);

        void AddRange(params IValuedLog[] valuedLogs);

        void Clear(Predicate<IValuedLog> match);

        void Error(object value, string message);

        void Failure(object value, string message);

        void Info(object value, string message);

        void Success(object value, string message);

        void Warning(object value, string message);
    }

    public interface IValuedLogbook<T> : IReadOnlyValuedLogbook<T>
    {
        void Add(IValuedLog<T> valuedLog);

        void Add(T value, string message, LogType logType);

        void AddRange(IEnumerable<IValuedLog<T>> valuedLogs);

        void AddRange(params IValuedLog<T>[] valuedLogs);

        void Clear(Predicate<IValuedLog<T>> match);

        void Error(T value, string message);

        void Failure(T value, string message);

        void Info(T value, string message);

        void Success(T value, string message);

        void Warning(T value, string message);
    }
}