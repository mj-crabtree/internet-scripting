namespace week1
{
    public static class Factory
    {
        public static Exercises.Person Person()
        {
            return new Exercises.Person();
        }

        public static Exercises.Date Date()
        {
            return new Exercises.Date();
        }

        public static Exercises.FunkyConsole FunkyConsole()
        {
            return new Exercises.FunkyConsole();
        }
    }
}