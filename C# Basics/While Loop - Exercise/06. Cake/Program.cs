using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int wight = int.Parse(Console.ReadLine());
            double pieces = lenght * wight;
            double guestsTaking = 0;

            while (pieces > 0)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                    break;
                double taking = double.Parse(input);
                pieces -= taking;
                guestsTaking += taking;

            }
            if (pieces < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{pieces} pieces are left.");
            }
        }
    }
}
