using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());
            double fourth = double.Parse(Console.ReadLine());

            double operation1 = (first + second);
            double operation2 = operation1 / third;
            double operation3 = operation2 * fourth;

            Console.WriteLine($"{operation3}");

        }
    }
}
