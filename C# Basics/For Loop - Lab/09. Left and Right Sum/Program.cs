using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int sum2 = 0;
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;
            for (int i = 1; i <= n; i++)//Същото като в предната задача(едно и също)!
            {
                int currentNumb = int.Parse(Console.ReadLine());
                sum += currentNumb;
                if (currentNumb > maxNumber)
                {
                    maxNumber = currentNumb;
                }
                if (currentNumb < minNumber)
                {
                    minNumber = currentNumb;
                }
            }
            for (int i = 1; i <= n; i++)
            {
                int currentNumb = int.Parse(Console.ReadLine());
                sum2 += currentNumb;
                if (currentNumb > maxNumber)
                {
                    maxNumber = currentNumb;
                }
                if (currentNumb < minNumber)
                {
                    minNumber = currentNumb;
                }
            }
            if (sum == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum}");
            }
            else if (sum > sum2)
            {
                Console.WriteLine($"No, diff = {sum - sum2}");
            }
            else
            {
                Console.WriteLine($"No, diff = {sum2 - sum}");
            }
        }
    }
}
