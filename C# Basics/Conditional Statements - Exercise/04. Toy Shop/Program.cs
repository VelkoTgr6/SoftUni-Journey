using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumExursion = double.Parse(Console.ReadLine());
            double puzzles = double.Parse(Console.ReadLine());
            double talkingDoll = double.Parse(Console.ReadLine());
            double teddyBear = double.Parse(Console.ReadLine());
            double minion = double.Parse(Console.ReadLine());
            double toyTruck = double.Parse(Console.ReadLine());


            double totalSum = ((puzzles * 2.60) + (talkingDoll * 3) + (teddyBear * 4.10) + (minion * 8.20) + (toyTruck * 2));
            double toysCount = puzzles + talkingDoll + teddyBear + minion + toyTruck;
            double finalSumWhitRent = totalSum *= 0.90;


            if (toysCount >= 50)
            {
                finalSumWhitRent *= 0.75;
            }

            if (finalSumWhitRent >= sumExursion)
            {

                Console.WriteLine($"Yes! {finalSumWhitRent - sumExursion:f2} lv left.");
            }
            else if (sumExursion > finalSumWhitRent)
            {

                Console.WriteLine($"Not enough money! {sumExursion - finalSumWhitRent:f2} lv needed.");
            }
        }
    }
}
