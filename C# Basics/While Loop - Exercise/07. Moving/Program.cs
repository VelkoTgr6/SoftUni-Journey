using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int wight = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double availableSpace = wight * lenght * height;
            string input;
            double boxes = 0;

            while ((input = Console.ReadLine()) != "Done")
            {
                boxes += double.Parse(input);
                if (boxes > availableSpace)
                    break;

            }
            if (boxes > availableSpace)
            {
                Console.WriteLine($"No more free space! You need {boxes - availableSpace} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{availableSpace - boxes} Cubic meters left.");
            }
        }
    }
}
