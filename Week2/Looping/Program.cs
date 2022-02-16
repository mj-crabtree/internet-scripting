using System;

namespace Looping
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] characters = { "Homer", "Marge", "Bart", "Lisa", "Maggie", "Grandpa", "Santas Little Helper" };
            /* int iCount;
            for (iCount = 0; iCount < characters.Length; iCount++) {
                Console.WriteLine($"{characters[iCount]}");
            } */
            /* int jCount = 0;
            while (jCount < characters.Length)
            {
                Console.WriteLine($"{characters[jCount]}");
                jCount++;
            } */
            int jCount = 0;
            do
            {
                Console.WriteLine($"{characters[jCount]}");
                jCount++;
            } while (jCount < characters.Length);
        }
    }
}
