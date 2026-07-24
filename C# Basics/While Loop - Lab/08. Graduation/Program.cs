using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            double markSum = 0;
            int expelled = 0;
            while (grade <= 12)
            {
                double currentMark = double.Parse(Console.ReadLine());
                markSum += currentMark;
                if (currentMark < 4)
                {
                    expelled++;
                    if (expelled > 1)
                    {
                        break;
                    }
                    continue;
                }
                grade++;

            }
            if (expelled > 1)
            {
                Console.WriteLine($"{name} has been excluded at {grade} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {markSum / 12:f2}");
            }
        }
    }
}
