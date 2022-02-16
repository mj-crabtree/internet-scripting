using System.Timers;

namespace week3
{
    public static class Factory
    {
        public static Calculator Calculator()
        {
            return new Calculator();
        }

        public static Timer Timer(int interval)
        {
            return new Timer(interval);
        }
    }
}