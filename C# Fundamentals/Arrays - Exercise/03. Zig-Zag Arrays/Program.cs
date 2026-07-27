using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArray = new int[n];
            int[] secondArray = new int[n];

            for (int index = 0; index < n; index++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (index % 2 == 0)
                {
                    firstArray[index] = input[0];
                    secondArray[index] = input[1];
                }
                else
                {
                    secondArray[index] = input[0];
                    firstArray[index] = input[1];
                }
            }

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));





        }
    }
}
