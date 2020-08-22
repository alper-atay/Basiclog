namespace Basiclog
{
    public static class Logger
    {
        public static ILogbook New()
        {
            return new Logbook();
        }
    }
}