using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            int counter = 0;
            int bestCount = 0;
            string bestCountSymbol = "";

            for (int i = 0; i < input.Length-1; i++)
            {
                if (input[i] == input[i + 1])
                    counter++;
                else
                    counter = 1;

                if (counter>bestCount)
                {
                    bestCount = counter;
                        bestCountSymbol = input[i];
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write($"{bestCountSymbol} ");
            }
        }
    }
}
