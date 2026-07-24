using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double price = 0;


            switch (flower)
            {
                case "Roses": price = 5; break;
                case "Dahlias": price = 3.80; break;
                case "Tulips": price = 2.80; break;
                case "Narcissus": price = 3; break;
                case "Gladiolus": price = 2.50; break;
            }
            double totalSum = numFlowers * price;

            if (flower == "Roses" && numFlowers > 80)
            {
                totalSum *= 0.9;
            }
            else if (flower == "Dahlias" && numFlowers > 90)
            {
                totalSum *= 0.85;
            }
            else if (flower == "Tulips" && numFlowers > 80)
            {
                totalSum *= 0.85;
            }
            if (flower == "Narcissus" && numFlowers < 120)
            {
                totalSum *= 1.15;//115% ==totalSum=totaSum+(totalsum*0.15)
            }
            else if (flower == "Gladiolus" && numFlowers < 80)
            {
                totalSum *= 1.20;
            }

            if (totalSum <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flower} and {budget - totalSum:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalSum - budget:f2} leva more.");
            }
        }
    }
}
