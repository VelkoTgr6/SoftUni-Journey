using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int workers = 0;
            int days = 0;
            //int totalSum = 0;

            for (int i = n; i >=100; i-=10)
            {
                days++;
                workers += i - 26;
                if (days >= 2)
                    i -= 10;
                if (i < 100)
                {
                    workers -= 26;
                    break; 
                }
            }
            Console.WriteLine(days);
            Console.WriteLine(workers);
        }
    }
}
