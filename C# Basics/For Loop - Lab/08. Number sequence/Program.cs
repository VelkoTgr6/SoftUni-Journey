using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Number_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            for (int i = 1; i <= n; i++)//Същото като в предната задача(едно и също)!
            {
                int currentNumb = int.Parse(Console.ReadLine());

                if (currentNumb > maxNumber)
                {
                    maxNumber = currentNumb;
                }
                if (currentNumb < minNumber)
                {
                    minNumber = currentNumb;
                }

            }
            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
