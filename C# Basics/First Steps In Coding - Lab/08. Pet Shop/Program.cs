using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double dogsFood = double.Parse(Console.ReadLine()) * 2.50;
            double catsFood = double.Parse(Console.ReadLine()) * 4;

            Console.WriteLine(dogsFood + catsFood + " lv.");
        }
    }
}
