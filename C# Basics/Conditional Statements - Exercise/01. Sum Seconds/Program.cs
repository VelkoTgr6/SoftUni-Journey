using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firsttime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int secondsSum = firsttime + secondTime + thirdTime;
            int minutes = secondsSum / 60;
            int leftSeconds = secondsSum % 60;

            if (leftSeconds < 10)
            {
                Console.WriteLine($"{minutes}:0{leftSeconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{leftSeconds}");
            }
        }
    }
}
