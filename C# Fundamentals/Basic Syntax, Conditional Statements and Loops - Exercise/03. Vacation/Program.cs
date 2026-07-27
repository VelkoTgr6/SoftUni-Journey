using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double priceForPerson = 0;

            switch (type)
            {
                case "Students":
                    if (day == "Friday")
                        priceForPerson = 8.45;
                    else if (day == "Saturday")
                        priceForPerson = 9.80;
                    else
                        priceForPerson = 10.46;
                    break;
                case "Business":
                    if (day == "Friday")
                        priceForPerson = 10.90;
                    else if (day == "Saturday")
                        priceForPerson = 15.60;
                    else
                        priceForPerson = 16;
                    break;
                case "Regular":
                    if (day == "Friday")
                        priceForPerson = 15;
                    else if (day == "Saturday")
                        priceForPerson = 20;
                    else
                        priceForPerson = 22.50;
                    break;
            }
            double totalPrice = priceForPerson * people;
            if (type == "Students" && people >= 30)
                totalPrice *= 0.85;
            else if (type == "Business" && people >= 100)
                totalPrice = (people - 10) * priceForPerson;
            else if (type == "Regular" && people >= 10 && people <= 20)
                totalPrice *= 0.95;

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
