using System;
using System.Linq;
using Entities;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOneOutcomeA("Matthew Crabtree", "B00414581");
            PartOneOutcomeB();
        }

        static void PartOneOutcomeA(string name, string matricNumber)
        {
            System.Console.WriteLine($"{name} ({matricNumber})");
        }

        static void PartOneOutcomeB()
        {
            using (var context = new University())
            {
                var passingStudents = context.Students
                    .Where(s => s.ExamMark >= 40)
                    .OrderBy(s => s.Lastname)
                    .ToList();

                System.Console.WriteLine("Passed:");
                foreach (var s in passingStudents)
                {
                    var fullName = String.Format($"{s.Firstname} {s.Lastname}");
                    System.Console.Write($"\t{fullName,-18}\n");
                }

                var topStudent = passingStudents.Aggregate((s1, s2) => s1.ExamMark > s2.ExamMark ? s1 : s2);

                System.Console.WriteLine("Top Student:");
                System.Console.WriteLine($"\t{topStudent.Firstname} {topStudent.Lastname}");
            }
        }
    }
}
