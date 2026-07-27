using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Students> students = new List<Students>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ").ToArray();
                string firstName = command[0];
                string lastName = command[1];
                decimal grade = decimal.Parse(command[2]);
                Students student = new Students(firstName,lastName,grade);
                students.Add(student);
            }
            foreach (Students student in students.OrderByDescending(s=>s.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: { student.Grade}");
            }

            
        }
        class Students
        {
            public Students(string firstName, string lastName, decimal grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public decimal Grade { get; set; }
        }
    }
}
