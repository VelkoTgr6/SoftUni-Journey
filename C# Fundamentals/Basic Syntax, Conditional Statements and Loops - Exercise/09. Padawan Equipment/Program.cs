using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyGot = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double priceLighsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());
            int beltsBonus = 0;
            double sum = priceLighsabers * (studentsCount + Math.Ceiling(studentsCount * 0.1)) + priceRobes * studentsCount;//whithout belts


            for (int i = 1; i <= studentsCount; i++)
            {
                if (i % 6 == 0)
                    beltsBonus++;
            }
            if (beltsBonus == 0)
                sum += priceBelts * studentsCount;
            else
                sum += priceBelts * (studentsCount - beltsBonus);

            if (sum <= moneyGot)
            {
                Console.WriteLine($"The money is enough - it would cost {(sum):f2}lv.");
            }
            else
                Console.WriteLine($"John will need {(sum - moneyGot):f2}lv more.");

        }
    }
}
