using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basiclog.Internals
{
    internal class InternalValuedLogbook : IValuedLogbook
    {
        private readonly List<IValuedLog> _valuedLogs = new List<IValuedLog>();

        public bool HasError => _valuedLogs.Exists(x => x.LogType == LogType.Error);

        public bool HasFailure => _valuedLogs.Exists(x => x.LogType == LogType.Failure);

        public bool HasInfo => _valuedLogs.Exists(x => x.LogType == LogType.Info);

        public bool HasSuccess => _valuedLogs.Exists(x => x.LogType == LogType.Success);

        public bool HasWarning => _valuedLogs.Exists(x => x.LogType == LogType.Warning);

        public int NumberOfError => _valuedLogs.Count(x => x.LogType == LogType.Error);

        public int NumberOfFailure => _valuedLogs.Count(x => x.LogType == LogType.Failure);

        public int NumberOfInfo => _valuedLogs.Count(x => x.LogType == LogType.Info);

        public int NumberOfSuccess => _valuedLogs.Count(x => x.LogType == LogType.Success);

        public int NumberOfWarning => _valuedLogs.Count(x => x.LogType == LogType.Warning);

        public bool Safely => !HasError && !HasFailure;

        public void Add(IValuedLog valuedLog)
        {
            _valuedLogs.Add(valuedLog);
        }

        public void Add(object value, string message, LogType logType)
        {
            _valuedLogs.Add(InternalValuedLog.New(value, message, logType));
        }

        public void Add(ILog log)
        {
            _valuedLogs.Add(InternalValuedLog.New(null, log));
        }

        public void Add(string message, LogType logType)
        {
            _valuedLogs.Add(InternalValuedLog.New(null, message, logType));
        }

        public void AddRange(IEnumerable<IValuedLog> valuedLogs)
        {
            _valuedLogs.AddRange(valuedLogs);
        }

        public void AddRange(params IValuedLog[] valuedLogs)
        {
            _valuedLogs.AddRange(valuedLogs);
        }

        public void AddRange(IEnumerable<ILog> logs)
        {
            _valuedLogs.AddRange(logs.Select(x => InternalValuedLog.New(null, x)));
        }

        public void AddRange(params ILog[] logs)
        {
            _valuedLogs.AddRange(logs.Select(x => InternalValuedLog.New(null, x)));
        }

        public void Clear()
        {
            _valuedLogs.Clear();
        }

        public void Clear(Predicate<IValuedLog> match)
        {
            _valuedLogs.RemoveAll(match);
        }

        public void Clear(Predicate<ILog> match)
        {
            _valuedLogs.RemoveAll(match);
        }

        public void Error(object value, string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewError(value, message));
        }

        public void Error(string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewError(null, message));
        }

        public void Failure(object value, string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewFailure(value, message));
        }

        public void Failure(string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewFailure(null, message));
        }

        public void Info(object value, string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewInfo(value, message));
        }

        public void Info(string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewFailure(null, message));
        }

        public void Success(object value, string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewSuccess(value, message));
        }

        public void Success(string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewFailure(null, message));
        }

        public void Warning(object value, string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewWarning(value, message));
        }

        public void Warning(string message)
        {
            _valuedLogs.Add(InternalValuedLog.NewWarning(null, message));
        }

        #region IEnumerable

        public IEnumerator<IValuedLog> GetEnumerator()
        {
            return _valuedLogs.GetEnumerator();
        }

        IEnumerator<ILog> IEnumerable<ILog>.GetEnumerator()
        {
            return _valuedLogs.Cast<ILog>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _valuedLogs.GetEnumerator();
        }

        #endregion IEnumerable
    }

    internal class InternalValuedLogbook<T> : IValuedLogbook<T>
    {
        private readonly List<IValuedLog<T>> _valuedLogs = new List<IValuedLog<T>>();

        public bool HasError => _valuedLogs.Exists(x => x.LogType == LogType.Error);

        public bool HasFailure => _valuedLogs.Exists(x => x.LogType == LogType.Failure);

        public bool HasInfo => _valuedLogs.Exists(x => x.LogType == LogType.Info);

        public bool HasSuccess => _valuedLogs.Exists(x => x.LogType == LogType.Success);

        public bool HasWarning => _valuedLogs.Exists(x => x.LogType == LogType.Warning);

        public int NumberOfError => _valuedLogs.Count(x => x.LogType == LogType.Error);

        public int NumberOfFailure => _valuedLogs.Count(x => x.LogType == LogType.Failure);

        public int NumberOfInfo => _valuedLogs.Count(x => x.LogType == LogType.Info);

        public int NumberOfSuccess => _valuedLogs.Count(x => x.LogType == LogType.Success);

        public int NumberOfWarning => _valuedLogs.Count(x => x.LogType == LogType.Warning);

        public bool Safely => !HasError && !HasFailure;

        public void Add(IValuedLog<T> valuedLog)
        {
            _valuedLogs.Add(valuedLog);
        }

        public void Add(T value, string message, LogType logType)
        {
            _valuedLogs.Add(InternalValuedLog<T>.New(value, message, logType));
        }

        public void Add(ILog log)
        {
            _valuedLogs.Add(InternalValuedLog<T>.New(default, log));
        }

        public void Add(string message, LogType logType)
        {
            _valuedLogs.Add(InternalValuedLog<T>.New(default, message, logType));
        }

        public void AddRange(IEnumerable<IValuedLog<T>> valuedLogs)
        {
            _valuedLogs.AddRange(valuedLogs);
        }

        public void AddRange(params IValuedLog<T>[] valuedLogs)
        {
            _valuedLogs.AddRange(valuedLogs);
        }

        public void AddRange(IEnumerable<ILog> logs)
        {
            _valuedLogs.AddRange(logs.Select(x => InternalValuedLog<T>.New(default, x)));
        }

        public void AddRange(params ILog[] logs)
        {
            _valuedLogs.AddRange(logs.Select(x => InternalValuedLog<T>.New(default, x)));
        }

        public void Clear()
        {
            _valuedLogs.Clear();
        }

        public void Clear(Predicate<IValuedLog<T>> match)
        {
            _valuedLogs.RemoveAll(match);
        }

        public void Clear(Predicate<ILog> match)
        {
            _valuedLogs.RemoveAll(match);
        }

        public void Error(T value, string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewError(value, message));
        }

        public void Error(string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewError(default, message));
        }

        public void Failure(T value, string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewFailure(value, message));
        }

        public void Failure(string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewFailure(default, message));
        }

        public void Info(T value, string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewInfo(value, message));
        }

        public void Info(string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewFailure(default, message));
        }

        public void Success(T value, string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewSuccess(value, message));
        }

        public void Success(string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewFailure(default, message));
        }

        public void Warning(T value, string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewWarning(value, message));
        }

        public void Warning(string message)
        {
            _valuedLogs.Add(InternalValuedLog<T>.NewWarning(default, message));
        }

        #region IEnumerable

        public IEnumerator<IValuedLog<T>> GetEnumerator()
        {
            return _valuedLogs.GetEnumerator();
        }

        IEnumerator<IValuedLog> IEnumerable<IValuedLog>.GetEnumerator()
        {
            return _valuedLogs.Cast<IValuedLog>().GetEnumerator();
        }

        IEnumerator<ILog> IEnumerable<ILog>.GetEnumerator()
        {
            return _valuedLogs.Cast<ILog>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _valuedLogs.GetEnumerator();
        }

        #endregion IEnumerable
    }
}