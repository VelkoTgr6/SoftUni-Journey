using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            Sum(product,quantity);
        }
            static void Sum(string product,double quantity)
            {
            switch (product)
            {
                case "water":
                     quantity *= 1.00;
                    break;
                case "coffee":
                     quantity *= 1.50;
                    break;
                case "coke":
                    quantity *= 1.40;
                    break;
                case "snacks":
                    quantity *= 2.00;
                    break;
            }
            Console.WriteLine($"{quantity:f2}");
            }
        
    }
}
