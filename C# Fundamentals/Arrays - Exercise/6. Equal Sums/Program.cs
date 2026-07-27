using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            //int leftSum = 0;
            //int rightSum = 0;
            bool isFound = false;

            if (input.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < input.Length; i++)
            {
                int leftSum = 0;
                for (int left = 0; left < i; left++)
                {
                    leftSum += input[left];
                }
                int rightSum = 0;
                for (int right =input.Length-1; right > i; right--)
                {
                    rightSum += input[right];
                }
                if (leftSum==rightSum && !isFound)
                {
                    Console.WriteLine(i);
                    isFound = true;
                }
                
            }
            if (!isFound)
                Console.WriteLine("no");
        }
    }
}
