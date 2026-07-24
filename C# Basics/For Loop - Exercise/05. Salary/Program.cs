using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            string sites = "";

            int facebook = 150;
            int instagram = 100;
            int reddit = 50;
            int sum = 0;

            for (int i = 1; i <= openTabs; i++)
            {
                sites = Console.ReadLine();

                switch (sites)
                {
                    case "Facebook":
                        sum += 150;
                        break;
                    case "Instagram":
                        sum += 100;
                        break;
                    case "Reddit":
                        sum += 50;
                        break;
                }
            }

            if (salary <= sum)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - sum);
            }

        }
    }
}
