using System.Collections.Generic;

namespace Basiclog
{
    public interface IReadOnlyValuedLogbook : IReadOnlyLogbook, IEnumerable<IValuedLog>
    {
    }

    public interface IReadOnlyValuedLogbook<T> : IReadOnlyValuedLogbook, IEnumerable<IValuedLog<T>>
    {
    }
}