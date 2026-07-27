using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            //int counter=0;
            var resources = new Dictionary<string, List<int>>();
            while ((command=Console.ReadLine())!="stop")
            {
                int value = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(command))
                {
                    resources.Add(command,new List<int>());
                    resources[command].Add(value);
                }
                else
                {
                    var increaseValue = resources[command];                
                }
                
            // Gold 
            // 155
            // Gold
            // 155          
            }
            foreach (var reseource in resources)
            {
                Console.WriteLine($"{reseource.Key} -> {string.Join(" ",reseource.Value)}");
                
            }
        }
    }
}
