using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int numberOfPencils = int.Parse(Console.ReadLine());
            int numberOfMarkers = int.Parse(Console.ReadLine());
            int littersCleaningLiquid = int.Parse(Console.ReadLine());
            double discountParcent = double.Parse(Console.ReadLine());

            //calculations
            double sumPencils = numberOfPencils * 5.80;
            double sumMarkers = numberOfMarkers * 7.20;
            double sumCleaningLiquid = littersCleaningLiquid * 1.20;
            double sumWhitoutDiscount = sumPencils + sumMarkers + sumCleaningLiquid;
            double discount = discountParcent / 100;
            double sumFinallDiscount = sumWhitoutDiscount - (sumWhitoutDiscount * discount);

            Console.WriteLine(sumFinallDiscount);
        }
    }
}
