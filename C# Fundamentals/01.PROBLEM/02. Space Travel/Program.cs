using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Space_Travel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> travelRoute = Console.ReadLine()
            .Split('|','|',' ')
            .ToList();
            travelRoute.RemoveAll(s => s == "");
            int startingFuel = int.Parse(Console.ReadLine());
            int ammoStarting = int.Parse(Console.ReadLine());
            bool isFailed = false;

               for (int i = 0; i <travelRoute.Count; i+=2)
                {
                    switch (travelRoute[i])
                    {
                        case "Travel":
                            int traveled = int.Parse(travelRoute[i+1]); 
                        if (startingFuel < int.Parse(travelRoute[i + 1]))
                        {
                            Console.WriteLine("Mission failed.");
                            isFailed = true;
                        }
                        else
                         {
                            startingFuel -= traveled;
                            Console.WriteLine($"The spaceship travelled {travelRoute[i+1]} light-years."); 
                        }
                            break;  
                        case "Enemy":
                       if (ammoStarting >= int.Parse(travelRoute[i + 1]))
                       {
                       int enemy = int.Parse(travelRoute[i + 1]);
                       ammoStarting -= enemy;
                       Console.WriteLine($"An enemy with {travelRoute[i+1]} armour is defeated.");
                       }
                       else if(ammoStarting < int.Parse(travelRoute[i + 1]))
                       {
                            if (startingFuel * 2 < int.Parse(travelRoute[i + 1]))
                            {
                                Console.WriteLine("Mission failed.");
                                isFailed = true;
                            }
                            else
                            {
                                startingFuel -= int.Parse(travelRoute[i + 1]) * 2;
                                Console.WriteLine($"An enemy with {travelRoute[i + 1]} armour is outmaneuvered.");
                            }
                       }
                            break;
                        case "Repair":
                            startingFuel += int.Parse(travelRoute[i + 1]);
                            ammoStarting += int.Parse(travelRoute[i + 1]) * 2;
                            Console.WriteLine($"Ammunitions added: {int.Parse(travelRoute[i + 1])*2}.");
                            Console.WriteLine($"Fuel added: {int.Parse(travelRoute[i+1])}.");
                            break;
                        case "Titan":
                        Console.WriteLine("You have reached Titan, all passengers are safe.");
                        isFailed = true;
                            break;
                    }
                if (isFailed)
                    break;
            }
        }
    }
}
