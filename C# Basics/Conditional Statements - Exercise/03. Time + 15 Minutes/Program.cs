using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());

            int sum = secondTime + 15;

            if (sum > 59)
            {
                firstTime += 1;
                secondTime = (secondTime + 15) % 60;
            }

            else
            {
                secondTime = secondTime + 15;
            }

            if (firstTime >= 24)
            {
                firstTime = 00;
            }
            if (secondTime < 10)
            {
                Console.WriteLine($"{firstTime}:0{secondTime}");
            }
            else
            {
                Console.WriteLine($"{firstTime}:{secondTime}");
            }

        }
    }
}
