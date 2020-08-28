namespace Basiclog
{
    public interface IValuedLog : ILog
    {
        object Value { get; }
    }

    public interface IValuedLog<out T> : IValuedLog
    {
        new T Value { get; }
    }
}