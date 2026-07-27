using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal total = 0;
            for (int i = 1; i <=n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                total += number;
            }
            Console.WriteLine($"{total}");

        }
    }
}
