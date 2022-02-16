using System;
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace week3
{
    public static class Utils
    {
        public static bool EmailChecker(string passedEmail)
        {
            return new EmailAddressAttribute().IsValid(passedEmail);
        }
        
        public static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine($"{e.SignalTime:h:mm:ss tt}");
        }
    }
}