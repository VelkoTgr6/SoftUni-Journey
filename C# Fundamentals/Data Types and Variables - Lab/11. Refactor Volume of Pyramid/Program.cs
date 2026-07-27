using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght, width, height,volume = 0;
            
            lenght = double.Parse(Console.ReadLine());
            Console.Write("Length: ");
            width = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            height = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            volume = (lenght * width * height) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");
        }
    }
}
