using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetOfPetar = double.Parse(Console.ReadLine());
            int numberOfVideoCards = int.Parse(Console.ReadLine());
            int numberOfProcessors = int.Parse(Console.ReadLine());
            int numberOfRAM = int.Parse(Console.ReadLine());

            double sumVideoCards = numberOfVideoCards * 250;
            double sumProcessors = numberOfProcessors * (sumVideoCards * 0.35);
            double sumRAM = numberOfRAM * (sumVideoCards * 0.10);
            double finallSum = sumVideoCards + sumRAM + sumProcessors;


            if (numberOfVideoCards > numberOfProcessors)
            {
                finallSum *= 0.85;
                //Console.WriteLine(finallSum);
            }

            if (budgetOfPetar >= finallSum)
            {
                Console.WriteLine($"You have {budgetOfPetar - finallSum:f2} leva left!");
            }
            else if (budgetOfPetar < finallSum)
            {
                Console.WriteLine($"Not enough money! You need {finallSum - budgetOfPetar:f2} leva more!");
            }
        }
    }
}
