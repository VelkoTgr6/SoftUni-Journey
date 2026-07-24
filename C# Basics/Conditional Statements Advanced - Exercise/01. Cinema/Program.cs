using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());
            double income = 0;

            switch (type)
            {
                case "Premiere":
                    income = rows * colums * 12.00;
                    Console.WriteLine($"{income:f2}");
                    break;
                case "Normal":
                    income = rows * colums * 7.50;
                    Console.WriteLine($"{income:f2}");
                    break;
                case "Discount":
                    income = rows * colums * 5.00;
                    Console.WriteLine($"{income:f2}");
                    break;
            }
    }
}
