using System;
using System.Collections.Generic;

namespace Basiclog
{
    public interface ILogbook : IReadOnlyLogbook
    {
        void Add(ILog log);

        void Add(string message, LogType logType);

        void AddRange(IEnumerable<ILog> logs);

        void AddRange(params ILog[] logs);

        void Clear();

        void Clear(Predicate<ILog> match);

        void Error(string message);

        void Failure(string message);

        void Info(string message);

        void Success(string message);

        void Warning(string message);
    }
}