using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            double sum = 0;
            

            for (double i = n; i >=0 ; i-=0)
            {
                double lastDigit = i % 10;
                i -= lastDigit ;
                if (lastDigit == 0)
                    i /= 10;
                sum += lastDigit;
                if (i == 0)
                    break;
            }
            Console.WriteLine(sum);
        }
    }
}
