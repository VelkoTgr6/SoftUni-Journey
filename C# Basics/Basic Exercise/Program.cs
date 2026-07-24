using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Steps_In_Coding___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // input
            double dollars = double.Parse(Console.ReadLine());

            // calculations
            double rate = 1.79549;
            double leva = dollars * rate;

            // output
            Console.WriteLine(leva);
        }
    }
}
