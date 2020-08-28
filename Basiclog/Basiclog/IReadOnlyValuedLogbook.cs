using System.Collections.Generic;

namespace Basiclog
{
    public interface IReadOnlyValuedLogbook : IReadOnlyLogbook, IEnumerable<IValuedLog>
    {
    }

    public interface IReadOnlyValuedLogbook<out T> : IReadOnlyValuedLogbook, IEnumerable<IValuedLog<T>>
    {
    }
}