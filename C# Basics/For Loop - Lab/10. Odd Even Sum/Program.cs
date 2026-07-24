using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNum;
                }
                else
                {
                    oddSum += currentNum;
                }
            }
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {oddSum}");
            }
            else if (oddSum > evenSum)
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {oddSum - evenSum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {evenSum - oddSum}");
            }
        }
    }
}
