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
            double moneyNeeded = double.Parse(Console.ReadLine());
            double moneyHave = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendingCounter = 0;
            //double spend = 0;
            double saved = moneyHave;
            while (moneyNeeded > saved)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (saved <= 0)
                {
                    saved = 0;
                }
                switch (command)
                {
                    case "spend":
                        saved -= money;
                        spendingCounter++; break;
                    case "save":
                        saved += money;
                        spendingCounter = 0; break;
                }

                daysCounter++;
                if (spendingCounter >= 5)
                    break;

            }
            if (spendingCounter >= 5 || saved < moneyNeeded)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            else
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
