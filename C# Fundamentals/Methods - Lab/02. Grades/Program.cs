using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputGrade = double.Parse(Console.ReadLine());
            PrintFail(inputGrade);
            PrintPoor(inputGrade);
            PrintGood(inputGrade);
            PrintVeryGood(inputGrade);
            PrintExellent(inputGrade);
        }
        static void PrintFail(double inputGrade)
        {
            if (inputGrade >= 2.00 && inputGrade <= 2.99)
                Console.WriteLine("Fail");
        }
        static void PrintPoor(double inputGrade)
        {
            if (inputGrade >= 3.00 && inputGrade <= 3.49)
                Console.WriteLine("Poor");
        }
        static void PrintGood(double inputGrade)
        {
            if (inputGrade >= 3.50 && inputGrade <= 4.49)
                Console.WriteLine("Good");
        }
        static void PrintVeryGood(double inputGrade)
        {
            if (inputGrade >= 4.50 && inputGrade <= 5.49)
                Console.WriteLine("Very good");
        }
        static void PrintExellent(double inputGrade)
        {
            if (inputGrade >= 5.50 && inputGrade<=6.00)
                Console.WriteLine("Excellent");
        }
    }
}
