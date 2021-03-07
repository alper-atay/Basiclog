using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Basiclog.Internals
{
    internal sealed class InternalObservableLogbook : IObservableLogbook
    {
        private readonly ObservableCollection<ILog> _logs = new ObservableCollection<ILog>();

        public InternalObservableLogbook()
        {
            _logs.CollectionChanged += CollectionChanged;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public bool HasError => NumberOfError > 0;

        public bool HasFailure => NumberOfFailure > 0;

        public bool HasInfo => NumberOfInfo > 0;

        public bool HasSuccess => NumberOfSuccess > 0;

        public bool HasWarning => NumberOfWarning > 0;

        public int NumberOfError => this.Count(x => x.LogType == LogType.Error);

        public int NumberOfFailure => this.Count(x => x.LogType == LogType.Failure);

        public int NumberOfInfo => this.Count(x => x.LogType == LogType.Info);

        public int NumberOfSuccess => this.Count(x => x.LogType == LogType.Success);

        public int NumberOfWarning => this.Count(x => x.LogType == LogType.Warning);

        public bool Safely => !HasError && !HasFailure;

        public string Name { get; }

        public void Add(ILog log)
        {
            _logs.Add(log);
        }

        public void Add(string message, LogType logType)
        {
            _logs.Add(InternalLog.New(message, logType));
        }

        public void AddRange(IEnumerable<ILog> logs)
        {
            foreach (ILog log in logs)
            {
                _logs.Add(log);
            }
        }

        public void AddRange(params ILog[] logs)
        {
            foreach (ILog log in logs)
            {
                _logs.Add(log);
            }
        }

        public void Clear()
        {
            _logs.Clear();
        }

        public void Clear(Predicate<ILog> match)
        {
            IEnumerable<ILog> matchedLogs = this.Where(x => match.Invoke(x));
            foreach (ILog matchedLog in matchedLogs)
            {
                _logs.Remove(matchedLog);
            }
        }

        public void Error(string message)
        {
            _logs.Add(InternalLog.NewError(message));
        }

        public void Failure(string message)
        {
            _logs.Add(InternalLog.NewFailure(message));
        }

        public void Info(string message)
        {
            _logs.Add(InternalLog.NewInfo(message));
        }

        public void Success(string message)
        {
            _logs.Add(InternalLog.NewSuccess(message));
        }

        public void Warning(string message)
        {
            _logs.Add(InternalLog.NewWarning(message));
        }

        #region IEnumerable

        public IEnumerator<ILog> GetEnumerator()
        {
            return _logs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _logs.GetEnumerator();
        }

        #endregion IEnumerable
    }
}