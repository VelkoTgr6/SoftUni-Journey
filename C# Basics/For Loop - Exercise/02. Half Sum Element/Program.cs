using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumb = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int currentNumb = int.Parse(Console.ReadLine());
                sum += currentNumb;

                if (currentNumb > maxNumb)
                {
                    maxNumb = currentNumb;
                }
            }
            int sumWhitoutMaxNumb = sum - maxNumb;
            if (maxNumb == sumWhitoutMaxNumb)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + maxNumb);
            }
            else
            {
                int diff = Math.Abs(maxNumb - sumWhitoutMaxNumb);
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
