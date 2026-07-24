using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string objects = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double finalSum = 0;

            bool isDayCorrect = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday" || day == "Saturday" || day == "Sunday";

            if (isDayCorrect == false)
            {
                Console.WriteLine("error");
            }
            else if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {

                switch (objects)
                {
                    case "banana": Console.WriteLine($"{finalSum = quantity * 2.50:f2}"); break;
                    case "apple": Console.WriteLine($"{finalSum = quantity * 1.2:f2}"); break;
                    case "orange": Console.WriteLine($"{finalSum = quantity * 0.85:f2}"); break;
                    case "grapefruit": Console.WriteLine($"{finalSum = quantity * 1.45:f2}"); break;
                    case "kiwi": Console.WriteLine($"{finalSum = quantity * 2.70:f2}"); break;
                    case "pineapple": Console.WriteLine($"{finalSum = quantity * 5.50:f2}"); break;
                    case "grapes": Console.WriteLine($"{finalSum = quantity * 3.85:f2}"); break;
                    default: Console.WriteLine("error"); break;
                }
            }

            else if (day == "Saturday" || day == "Sunday")
            {
                switch (objects)
                {
                    case "banana": Console.WriteLine($"{finalSum = quantity * 2.70:f2}"); break;
                    case "apple": Console.WriteLine($"{finalSum = quantity * 1.25:f2}"); break;
                    case "orange": Console.WriteLine($"{finalSum = quantity * 0.90:f2}"); break;
                    case "grapefruit": Console.WriteLine($"{finalSum = quantity * 1.60:f2}"); break;
                    case "kiwi": Console.WriteLine($"{finalSum = quantity * 3.00:f2}"); break;
                    case "pineapple": Console.WriteLine($"{finalSum = quantity * 5.60:f2}"); break;
                    case "grapes": Console.WriteLine($"{finalSum = quantity * 4.20:f2}"); break;
                    default: Console.WriteLine("error"); break;
                }
            }

        }
    }
}
