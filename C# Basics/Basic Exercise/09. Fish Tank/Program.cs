using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            //calculations
            double volume = lenght * width * height;
            double volumeInLitters = volume / 1000;
            double occupiedspace = percentage / 100;
            double littersNeeded = volumeInLitters * (1 - occupiedspace);

            Console.WriteLine(littersNeeded);
        }
    }
}
