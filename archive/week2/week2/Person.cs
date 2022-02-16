using System;

namespace week2
{
    public class Person
    {
        public Person()
        {
            CaptureName();
            CaptureBirthDate();
            CalculateAge();
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        private DateTime BirthDate { get; set; }

        private void CaptureName()
        {
            Printer.Print("Enter your name");
            Name = Console.ReadLine();
        }

        private void CaptureBirthDate()
        {
            bool success = false;

            while (!success)
            {
                Printer.Print("Enter your date of birth (e.g. 09/03/1987)");
                string capture = Console.ReadLine();

                DateTime result;
                if (!DateTime.TryParse(capture, out result))
                {
                    Printer.Print("Invalid format, use DD/MM/YYYY");
                }
                else
                {
                    BirthDate = result;
                    success = true;
                }
            }
        }

        private void CalculateAge()
        {
            var today = DateTime.Today;
            Age = today.Year - BirthDate.Year;

            if (BirthDate > today.AddYears(-Age)) Age--;
        }

        public void PrintThings()
        {
            Printer.PrintGreeting(this);
            Printer.PrintAge(this);
        }
    }
}