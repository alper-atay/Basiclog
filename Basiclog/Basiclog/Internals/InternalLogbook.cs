﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basiclog.Internals
{
    internal sealed class InternalLogbook : ILogbook
    {
        private readonly List<ILog> _logs = new List<ILog>();

        public InternalLogbook(string name = default)
        {
            if (name is null)
            {
                Name = string.Empty;
            }
            else
            {
                Name = name;
            }
        }

        public bool HasError => _logs.Exists(x => x.LogType == LogType.Error);

        public bool HasFailure => _logs.Exists(x => x.LogType == LogType.Failure);

        public bool HasInfo => _logs.Exists(x => x.LogType == LogType.Info);

        public bool HasSuccess => _logs.Exists(x => x.LogType == LogType.Success);

        public bool HasWarning => _logs.Exists(x => x.LogType == LogType.Warning);

        public string Name { get; }

        public int NumberOfError => _logs.Count(x => x.LogType == LogType.Error);

        public int NumberOfFailure => _logs.Count(x => x.LogType == LogType.Failure);

        public int NumberOfInfo => _logs.Count(x => x.LogType == LogType.Info);

        public int NumberOfSuccess => _logs.Count(x => x.LogType == LogType.Success);

        public int NumberOfWarning => _logs.Count(x => x.LogType == LogType.Warning);

        public bool Safely => !HasError && !HasFailure;

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
            _logs.AddRange(logs);
        }

        public void AddRange(params ILog[] logs)
        {
            _logs.AddRange(logs);
        }

        public void Clear()
        {
            _logs.Clear();
        }

        public void Clear(Predicate<ILog> match)
        {
            _logs.RemoveAll(match);
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