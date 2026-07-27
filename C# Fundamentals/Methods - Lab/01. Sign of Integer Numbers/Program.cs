using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PositiveNumber(input);
            NegativeNumber(input);
            zeroNumber(input);
        }
        static void PositiveNumber(int input)
        {
            if (input > 0)
                Console.WriteLine($"The number {input} is positive. ");
        }
        static void NegativeNumber(int input)
        {
            if(input<0)
                Console.WriteLine($"The number {input} is negative. ");
        }
        static void zeroNumber(int input)
        {
            if (input == 0)
                Console.WriteLine($"The number {input} is zero. ");
        }

    }
}
