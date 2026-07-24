using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double minNumb = double.MaxValue;
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                double number = double.Parse(input);
                if (number < minNumb)
                {
                    minNumb = number;
                }

                continue;
                number = double.Parse(Console.ReadLine());

            }

            Console.WriteLine(minNumb);
        }
    }
}
