using System;
using System.Linq;
using System.Collections.Generic;


namespace _05._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string end;
            var courses = new Dictionary<string, List<string>>();

            while ((end=Console.ReadLine())!="end")
            {
                string[] command = end.Split(" : ").ToArray();
                if (!courses.ContainsKey(command[0]))
                {
                    courses.Add(command[0], new List<string>());
                    courses[command[0]].Add(command[1]);
                }
                else
                {
                    courses[command[0]].Add(command[1]);
                }

            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {courses[course.Key].Count}");
                foreach (var people in courses)
                {
                    if (course.Key==people.Key)
                    {
                        Console.WriteLine($"-- {string.Join("\n-- ",course.Value)}");
                    }
                }
            }
        }
    }
}
