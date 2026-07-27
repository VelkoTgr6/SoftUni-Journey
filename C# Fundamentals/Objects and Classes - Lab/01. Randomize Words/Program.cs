using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Random random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                string pos1 = input[i];
                int randomIndex = random.Next(0, input.Length);
                string randomValue = input[randomIndex];

                input[i] = randomValue;
                input[randomIndex] = pos1;
                
            }
            foreach (string value in input)
            {
                Console.WriteLine(value);
            }
        }
    }
}
