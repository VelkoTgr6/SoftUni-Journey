using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i <input.Length; i++)
            {
                if (i<input.Length-1)
                {
                    if (input[i] > input[i + 1])
                    {
                        Console.Write($"{input[i]} ");
                    } 
                }
                else 
                {
                    Console.Write($"{input[i]} ");
                }
                
            }
        }
    }
}
