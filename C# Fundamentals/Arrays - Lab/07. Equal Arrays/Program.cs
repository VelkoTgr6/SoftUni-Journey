using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = Console.ReadLine()
                .Split( )
                .Select(int.Parse)
                .ToArray();

            int[] arr2 = Console.ReadLine()
                .Split( )
                .Select(int.Parse)
                .ToArray();
            int sum = 0;
            bool notIndentical = false;
            for (int i = 0; i < arr1.Length; i++)
            {
                int currentNumb = arr1[i];
                sum += currentNumb;
                if (arr1[i] != arr2[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    notIndentical = true;
                    break;
                }
            }
            if (notIndentical==false)
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
