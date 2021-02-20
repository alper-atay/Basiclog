namespace Basiclog
{
    public interface IValuedLog : ILog
    {
        object Value { get; }
    }

    public interface IValuedLog<T> : IValuedLog
    {
        new T Value { get; }
    }
}