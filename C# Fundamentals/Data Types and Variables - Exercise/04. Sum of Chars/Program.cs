using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 1; i <=n; i++)
            {
                char sym = char.Parse(Console.ReadLine());
                sum += sym;

            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
