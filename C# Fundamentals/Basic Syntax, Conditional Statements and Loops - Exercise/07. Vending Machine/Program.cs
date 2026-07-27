using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            double coins = double.Parse(Console.ReadLine());
            string command = coins.ToString();
            double sumClient = 0;
            double price = 0;
            double finalSum = 0;


            while (command != "End")
            {
                coins = Convert.ToDouble(command);
                if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1 && coins != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    coins = 0;
                }
                sumClient += coins;
                command = Console.ReadLine();
                if (command == "Start")
                {
                    while (command != "End")
                    {
                        command = Console.ReadLine();
                        switch (command)
                        {
                            case "Nuts":
                                price = 2;
                                finalSum += price; break;
                            case "Water":
                                price = 0.7;
                                finalSum += price; break;
                            case "Crisps":
                                price = 1.5;
                                finalSum += price; break;
                            case "Soda":
                                price = 0.8;
                                finalSum += price; break;
                            case "Coke":
                                price = 1;
                                finalSum += price; break;
                            default:
                                if (command != "End")
                                    Console.WriteLine("Invalid product"); break;
                        }
                        if (sumClient < finalSum && command != "End")
                        {
                            Console.WriteLine("Sorry, not enough money");
                            finalSum -= price;
                        }
                        else if (command != "Start" || command != "End")
                        {
                            switch (command)
                            {
                                case "Nuts": Console.WriteLine("Purchased nuts"); break;
                                case "Water": Console.WriteLine("Purchased water"); break;
                                case "Crisps": Console.WriteLine("Purchased crisps"); break;
                                case "Soda": Console.WriteLine("Purchased soda"); break;
                                case "Coke": Console.WriteLine("Purchased coke"); break;

                            }
                        }

                    }
                }
            }
            if (command == "End")
                Console.WriteLine($"Change: { sumClient - finalSum:f2}");
        }
    }
}
