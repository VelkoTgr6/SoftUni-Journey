using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int total = 0;
            int digit = 0;
            bool isSpecial = false;
            for (int ch = 1; ch <= n; ch++)
            {
                digit = ch;
                while (ch > 0)
                {
                    total += ch % 10;
                    ch = ch / 10;
                }
                isSpecial = (total == 5) || (total == 7) || (total == 11);
                Console.WriteLine("{0} -> {1}", digit, isSpecial);
                total = 0;
                ch = digit;
            }
        }
    }
}
