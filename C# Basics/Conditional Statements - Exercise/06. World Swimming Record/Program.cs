using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeInSecondsForSwimmingfor1metter = double.Parse(Console.ReadLine());

            double haveToSwim = distanceInMeters * timeInSecondsForSwimmingfor1metter;
            double secondsForMeters = Math.Floor(distanceInMeters / 15);
            haveToSwim += secondsForMeters * 12.5;
            //double sumTime=haveToSwim+calculationSecondsForMeters;


            if (haveToSwim >= recordInSeconds)
            {
                Console.WriteLine($"No, he failed! He was {haveToSwim - recordInSeconds:f2} seconds slower.");
            }
            else if (haveToSwim < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {haveToSwim:f2} seconds.");
            }
        }
    }
}
