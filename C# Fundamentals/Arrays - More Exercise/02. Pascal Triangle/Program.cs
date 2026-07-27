using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] row = new long[n];
            long[] current = new long[n];
            row[0] = 1; 
            Console.WriteLine(row[0]);
            for (int r = 1; r < n; r++)
            {
                current[0] = 1; 
                Console.Write($"{current[0]} ");
                for (int c = 1; c <= r; c++)
                {
                    current[c] = row[c - 1] + row[c];
                    Console.Write($"{current[c]} ");
                }
                for (int j = 0; j < n; j++)
                {
                    row[j] = current[j];
                }
                Console.WriteLine();
            }
            }
    }
}
