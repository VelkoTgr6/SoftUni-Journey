using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double finalSum = 0;

            if (city == "Sofia")
            {
                switch (product)
                {
                    case "coffee": finalSum = quantity * 0.50; break;
                    case "water": finalSum = quantity * 0.80; break;
                    case "beer": finalSum = quantity * 1.20; break;
                    case "sweets": finalSum = quantity * 1.45; break;
                    case "peanuts":
                        finalSum = quantity * 1.60; break;
                        break;
                }
            }
            else if (city == "Plovdiv")
            {
                switch (product)
                {
                    case "coffee": finalSum = quantity * 0.40; break;
                    case "water": finalSum = quantity * 0.70; break;
                    case "beer": finalSum = quantity * 1.15; break;
                    case "sweets": finalSum = quantity * 1.30; break;
                    case "peanuts":
                        finalSum = quantity * 1.50; break;
                        break;
                }
            }
            else if (city == "Varna")
            {
                switch (product)
                {
                    case "coffee": finalSum = quantity * 0.45; break;
                    case "water": finalSum = quantity * 0.70; break;
                    case "beer": finalSum = quantity * 1.10; break;
                    case "sweets": finalSum = quantity * 1.35; break;
                    case "peanuts":
                        finalSum = quantity * 1.55; break;
                        break;
                }
            }
            Console.WriteLine(finalSum);
        }
    }
}
