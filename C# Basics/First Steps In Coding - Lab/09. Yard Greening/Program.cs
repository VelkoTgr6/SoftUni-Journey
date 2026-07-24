using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double meters = double.Parse(Console.ReadLine()) * 7.61;
            double discount = 0.18;
            double finalPrice = meters - (meters * discount);

            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {meters * discount} lv.");
        }
    }
}
