using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double abs = double.MinValue;
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                double number = double.Parse(input);
                if (number > abs)
                    abs = number;

                continue;
                number = double.Parse(Console.ReadLine());

            }
            Console.WriteLine(abs);
        }
    }
}
