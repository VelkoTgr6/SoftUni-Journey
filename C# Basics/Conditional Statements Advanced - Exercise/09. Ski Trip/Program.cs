using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysResting = int.Parse(Console.ReadLine()) - 1;
            string roomType = Console.ReadLine();
            string rating = Console.ReadLine();

            double totalSum = 0;

            switch (roomType)
            {
                case "room for one person": totalSum = daysResting * 18; break;
                case "apartment": totalSum = daysResting * 25; break;
                case "president apartment": totalSum = daysResting * 35; break;
            }

            if (roomType == "apartment")
            {
                if (daysResting < 10)
                {
                    totalSum *= 0.7;
                }
                if (daysResting < 15)
                {
                    totalSum *= 0.65;
                }
                else if (daysResting > 15)
                {
                    totalSum *= 0.5;
                }

            }
            else if (roomType == "president apartment")
            {
                if (daysResting < 10)
                {
                    totalSum *= 0.9;
                }
                if (daysResting < 15)
                {
                    totalSum *= 0.85;
                }
                else if (daysResting > 15)
                {
                    totalSum *= 0.80;
                }

            }
            if (rating == "positive")
            {
                totalSum *= 1.25;
            }
            else
            {
                totalSum *= 0.9;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
