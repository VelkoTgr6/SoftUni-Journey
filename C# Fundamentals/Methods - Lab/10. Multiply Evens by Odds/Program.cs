using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEvenAndOdds(n));
        }
        static int GetMultipleOfEvenAndOdds(int n)
        {
            n=Math.Abs(n);
            int evens = 0;
            int odds = 0;

            for (int i = n; i >=0; i--)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                    evens += lastDigit;
                else
                    odds += lastDigit;

                n /= 10;
            }
            return evens * odds;
        }
    }
}
