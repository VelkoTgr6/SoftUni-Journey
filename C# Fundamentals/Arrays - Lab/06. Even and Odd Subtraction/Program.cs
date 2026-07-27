using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumb = numbers[i];
                if (currentNumb % 2 == 0)
                    evenSum += currentNumb;

                else
                    oddSum += currentNumb;
            }
            int difference =evenSum-oddSum;
            Console.WriteLine(difference);
        }
    }
}
