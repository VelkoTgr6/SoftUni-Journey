using System;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            //int counter=0;
            var resources = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "stop")
            {
                int value = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(command))
                {
                    resources.Add(command,value);   
                    //resources[command].Add(value);
                }
                else
                {
                    int increaseValue = resources[command];
                    increaseValue += value;
                    resources[command]=increaseValue;
                }

                // Gold 
                // 155  
                // Gold
                // 155               
            }   
            foreach (var reseource in resources)
            {
                Console.WriteLine($"{reseource.Key} -> {string.Join(" ", reseource.Value)}");

            }
        }
    }
}
