using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 1; i <=n; i++)
            {
                int p = int.Parse(Console.ReadLine());
                sum += p;

                if (sum>255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    sum -= p;
                }
                

            }
            Console.WriteLine(sum);
        }
    }
}
