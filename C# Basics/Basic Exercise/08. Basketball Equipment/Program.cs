using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int yearlyTax = int.Parse(Console.ReadLine());

            //calculations
            double sneakers = yearlyTax - (yearlyTax * 0.4);
            double outfit = sneakers - (sneakers * 0.2);
            double ball = outfit / 4;
            double accesories = ball / 5;
            double totallSum = sneakers + outfit + ball + accesories + yearlyTax;

            Console.WriteLine(totallSum);
        }
    }
}
