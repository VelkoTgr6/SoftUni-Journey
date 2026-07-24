using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double numFishermans = double.Parse(Console.ReadLine());
            double priceShip = 0;

            switch (season)
            {
                case "Spring": priceShip = 3000; break;
                case "Summer": priceShip = 4200; break;
                case "Autumn": priceShip = 4200; break;
                case "Winter": priceShip = 2600; break;
            }

            //double totalSum = budget-priceShip;

            if (numFishermans <= 6)
            {
                priceShip *= 0.90;
            }
            else if (numFishermans <= 11)
            {
                priceShip *= 0.85;
            }
            else
            {
                priceShip *= 0.75;
            }
            if (numFishermans % 2 == 0 && season != "Autumn")
            {
                priceShip *= 0.95;
            }
            if (budget >= priceShip)
            {
                Console.WriteLine($"Yes! You have {budget - priceShip:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {priceShip - budget:f2} leva.");
            }
        }
    }
}
