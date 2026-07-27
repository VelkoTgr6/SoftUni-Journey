using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            stri
            double baseNumb = double.Parse(Console.ReadLine());
            double powerNumb = double.Parse(Console.ReadLine());
            Console.WriteLine(RaiseToPower(baseNumb, powerNumb));

        }
        static double RaiseToPower(double baseNumb,double powerNumb)
        {
            double result = Math.Pow(baseNumb, powerNumb);
            return result;
        }
    }
}
