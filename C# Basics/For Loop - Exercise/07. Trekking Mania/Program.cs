using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int climbersGroups = int.Parse(Console.ReadLine());
            int climbersInGroups = 0;
            double musala = 0;
            double monblan = 0;
            double kilimandgaro = 0;
            double k2 = 0;
            double everest = 0;
            int sumPeople = 0;
            int totalPeople = 0;

            for (int i = 1; i <= climbersGroups; i++)
            {
                sumPeople = int.Parse(Console.ReadLine());
                totalPeople += sumPeople;
                if (sumPeople <= 5)
                    musala += sumPeople;
                else if (sumPeople <= 12)
                    monblan += sumPeople;
                else if (sumPeople <= 25)
                    kilimandgaro += sumPeople;
                else if (sumPeople <= 40)
                    k2 += sumPeople;
                else
                    everest += sumPeople;
            }
            Console.WriteLine($"{musala / totalPeople * 100:f2}%");
            Console.WriteLine($"{monblan / totalPeople * 100:f2}%");
            Console.WriteLine($"{kilimandgaro / totalPeople * 100:f2}%");
            Console.WriteLine($"{k2 / totalPeople * 100:f2}%");
            Console.WriteLine($"{everest / totalPeople * 100:f2}%");
        }
    }
}
