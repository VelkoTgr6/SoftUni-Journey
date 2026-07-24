using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Godzilla_vs.Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double statist = double.Parse(Console.ReadLine());
            double priceClotesForStatist = double.Parse(Console.ReadLine());

            double priceForDecor = budget * 0.10;
            double priceClothes = statist * priceClotesForStatist;

            if (statist > 150)
            {
                priceClothes *= 0.90;
            }
            double finalSumFilm = priceForDecor + priceClothes;

            if (budget >= finalSumFilm)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - finalSumFilm:f2} leva left.");
            }
            else if (finalSumFilm > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {finalSumFilm - budget:f2} leva more.");
            }
        }
    }
}
