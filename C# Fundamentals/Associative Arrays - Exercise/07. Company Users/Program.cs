using System;
using System.Linq;
using System.Collections.Generic;


namespace _07._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var company = new Dictionary<string, List<string> > ();
            while ((input=Console.ReadLine())!="End")
            {
                string[] command = input.Split(" -> ").ToArray();
                if (!company.ContainsKey(command[0]))
                {
                    company.Add(command[0], new List<string>());
                    company[command[0]].Add(command[1]);
                }
                else
                {
                        if (company[command[0]].Contains(command[1]))
                        {
                           continue;
                        }
                    company[command[0]].Add(command[1]);
                }

            }
            foreach (var companies in company)
            {
                Console.WriteLine(companies.Key);
                foreach (var item in company)
                {
                    if (item.Key==companies.Key)
                    {
                        Console.WriteLine($"-- {string.Join("\n-- ", companies.Value)}");

                    }
                }
            }
        }
    }
}
