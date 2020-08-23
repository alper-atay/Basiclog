namespace Basiclog
{
    public delegate IReadOnlyLogbook ReadOnlyLogbookPredicate<in T>(T obj);
}