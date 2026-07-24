using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int failTimesPossible = int.Parse(Console.ReadLine());
            int failedTimes = 0;
            int solvedPorblems = 0;
            double sumMarks = 0;
            string nameExercise = "";
            bool failed = true;

            while (failTimesPossible > failedTimes)
            {
                string nameProblem = Console.ReadLine();
                if (nameProblem == "Enough")
                {
                    break;
                    failed = false;

                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    failedTimes++;
                }
                sumMarks += grade;
                solvedPorblems++;
                nameExercise = nameProblem;
            }
            if (failedTimes >= failTimesPossible)
            {
                Console.WriteLine($"You need a break, {failedTimes} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {sumMarks / solvedPorblems:f2}");
                Console.WriteLine($"Number of problems: {solvedPorblems}");
                Console.WriteLine($"Last problem: {nameExercise}");
            }
        }
    }
}
