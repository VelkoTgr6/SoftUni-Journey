using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            if (budget <= 100)
            {
                switch (season)
                {
                    case "summer":
                        Console.WriteLine("Somewhere in Bulgaria ");
                        Console.WriteLine($"Camp - {budget * 0.3:f2}");
                        break;
                    case "winter":
                        Console.WriteLine("Somewhere in Bulgaria ");
                        Console.WriteLine($"Hotel - {budget * 0.7:f2}");
                        break;
                }
            }
            else if (budget <= 1000)
            {
                switch (season)
                {
                    case "summer":
                        Console.WriteLine("Somewhere in Balkans ");
                        Console.WriteLine($"Camp - {budget * 0.4:f2}");
                        break;
                    case "winter":
                        Console.WriteLine("Somewhere in Balkans ");
                        Console.WriteLine($"Hotel - {budget * 0.8:f2}");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Somewhere in Europe");
                Console.WriteLine($"Hotel - {budget * 0.9:f2}");
            }
        }
    }
}
