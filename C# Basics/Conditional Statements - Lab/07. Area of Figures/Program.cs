using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();


            //calculations
            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double result = a * a;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double result = a * b;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double result = Math.PI * r * r;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                double result = a * ha / 2;
                Console.WriteLine($"{result:f3}");
            }
            else if (figure == "trapec")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());
                double d = double.Parse(Console.ReadLine());
                double result = (a + b);
            }
        }
    }
}
