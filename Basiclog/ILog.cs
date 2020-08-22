using System;

namespace Basiclog
{
    public interface ILog
    {
        DateTime DateTime { get; }
        LogType LogType { get; }
        string Message { get; }
        TimeSpan Time { get; }
        string TimeString { get; }
    }
}