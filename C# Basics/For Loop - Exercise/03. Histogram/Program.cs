using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            int numb;

            for (int i = 1; i <= n; i++)
            {
                numb = int.Parse(Console.ReadLine());

                if (numb < 200)
                    p1++;
                else if (numb < 400)
                    p2++;
                else if (numb < 600)
                    p3++;
                else if (numb < 800)
                    p4++;
                else
                    p5++;
            }
            Console.WriteLine($"{(double)p1 / n * 100:f2}%");
            Console.WriteLine($"{(double)p2 / n * 100:f2}%");
            Console.WriteLine($"{(double)p3 / n * 100:f2}%");
            Console.WriteLine($"{(double)p4 / n * 100:f2}%");
            Console.WriteLine($"{(double)p5 / n * 100:f2}%");
        }
    }
}
