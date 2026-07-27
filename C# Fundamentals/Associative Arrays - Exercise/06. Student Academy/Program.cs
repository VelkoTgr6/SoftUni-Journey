using System;
using System.Linq;
using System.Collections.Generic;


namespace _06._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
                else
                {
                    students[name].Add(grade);
                }
            }
            foreach (var student in students)
            {
                if (students[student.Key].Sum() / students[student.Key].Count >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {Math.Abs(students[student.Key].Sum() / students[student.Key].Count):f2}");
                }
            }
            
        }
    }
}
