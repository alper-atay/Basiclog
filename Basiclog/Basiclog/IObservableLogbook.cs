using System.Collections.Specialized;

namespace Basiclog
{
    public interface IObservableLogbook : ILogbook, INotifyCollectionChanged
    {
    }
}