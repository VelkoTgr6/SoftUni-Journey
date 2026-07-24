using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegeterianMenu = int.Parse(Console.ReadLine());

            //calculations
            double priceChickenMenu = chickenMenu * 10.35;
            double pricefishMenu = fishMenu * 12.40;
            double priceVegeterianMenu = vegeterianMenu * 8.15;
            double totallSum = priceChickenMenu + pricefishMenu + priceVegeterianMenu;
            double priceDesert = totallSum * 0.2;
            double FinallPrice = totallSum + priceDesert + 2.5;

            Console.WriteLine(FinallPrice);
        }
    }
}
