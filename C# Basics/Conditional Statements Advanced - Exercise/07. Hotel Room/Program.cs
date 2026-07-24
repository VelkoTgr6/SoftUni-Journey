using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int daysForSleep = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartment = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studio = 50;
                    apartment = 65;
                    break;

                case "June":
                case "September":
                    studio = 75.20;
                    apartment = 68.70;
                    break;
                case "July":
                case "August":
                    studio = 76;
                    apartment = 77;
                    break;
            }
            double studioCost = daysForSleep * studio;
            double apartmentCost = daysForSleep * apartment;

            if (daysForSleep > 7 && daysForSleep <= 14)
            {
                if (month == "May" || month == "October")
                {
                    studioCost *= 0.95;
                }
            }
            else if (daysForSleep > 14)
            {
                if (month == "May" || month == "October")
                {
                    studioCost *= 0.70;
                }
                else if (month == "June" || month == "September")
                {
                    studioCost *= 0.80;
                }

                apartmentCost *= 0.90;
            }

            Console.WriteLine($"Apartment: {apartmentCost:f2} lv.");
            Console.WriteLine($"Studio: {studioCost:f2} lv.");
        }
    }
}
