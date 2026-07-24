using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageLilly = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int priceFor1Toy = int.Parse(Console.ReadLine());
            int money = 0;
            int selledToys = 0;
            int days = 0;

            for (int i = 1; i <= ageLilly; i += 1)
            {
                if (i % 2 == 0)
                {
                    money += i * 5 - 1;
                }
                else
                {
                    money += priceFor1Toy;
                }
            }
            if (money >= price)
            {
                Console.WriteLine($"Yes! {money - price:f2}");
            }
            else
            {
                Console.WriteLine($"No! {price - money:f2}");
            }
        }
    }
}
