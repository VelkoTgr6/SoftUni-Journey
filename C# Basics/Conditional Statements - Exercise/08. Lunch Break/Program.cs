using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfSerial = Console.ReadLine();
            int lenghtOfEpisodes = int.Parse(Console.ReadLine());
            int lenghtOfBreak = int.Parse(Console.ReadLine());

            double timeForLunch = lenghtOfBreak / 8.0;
            double timeForBreak = lenghtOfBreak / 4.0;
            double timeLeft = lenghtOfBreak - (timeForLunch + timeForBreak);

            if (timeLeft >= lenghtOfEpisodes)
            {
                double timeLeftWhNum = Math.Ceiling(timeLeft - lenghtOfEpisodes);
                Console.WriteLine($"You have enough time to watch {nameOfSerial} and left with {timeLeftWhNum} minutes free time.");
            }
            else
            {
                double timeNeeded = Math.Ceiling(lenghtOfEpisodes - timeLeft);
                Console.WriteLine($"You don't have enough time to watch {nameOfSerial}, you need {timeNeeded} more minutes.");
            }
        }
    }
}
