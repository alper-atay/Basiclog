using System.Collections.Generic;

namespace Basiclog
{
    public interface IReadOnlyLogbook : IEnumerable<ILog>
    {
        bool HasError { get; }

        bool HasFailure { get; }

        bool HasInfo { get; }

        bool HasSuccess { get; }

        bool HasWarning { get; }

        int NumberOfError { get; }

        int NumberOfFailure { get; }

        int NumberOfInfo { get; }

        int NumberOfSuccess { get; }

        int NumberOfWarning { get; }

        bool Safely { get; }
    }
}