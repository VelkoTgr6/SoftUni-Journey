using System;
using System.Linq;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, string>();
            for (int i = 1; i <=n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                if (command[0] == "unregister")
                {
                    if (!cars.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                    else
                    {
                        cars.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }

                }
                else
                {
                    if (!cars.ContainsKey(command[1]))
                    {
                        cars.Add(command[1], command[2]);

                            Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                    }
                    else
                    {
                            Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                    }
                }

            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }
        }
    }
}
