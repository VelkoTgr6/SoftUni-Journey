using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int i = 1; i <= ordersCount; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double formula = days * capsulesCount * pricePerCapsule;
                Console.WriteLine($"The price for the coffee is: ${formula:f2}");
                totalPrice += formula;
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
