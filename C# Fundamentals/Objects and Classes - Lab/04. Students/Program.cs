using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                // string firstName = tokens[0];
                // string lastName = tokens[1];  
                // int age = int.Parse(tokens[2]);
                // string city = tokens[3];

                // Student student = new Student(firstName, lastName, age, city);
                students.Add(new Student(tokens[0], tokens[1], int.Parse(tokens[2]), tokens[3]));
                //input = Console.ReadLine();
            }
            string cityFilter = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.City == cityFilter)
                {
                    Console.WriteLine($"{student.FirstName} { student.LastName} is { student.Age } years old.");
                }
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, int age, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}
