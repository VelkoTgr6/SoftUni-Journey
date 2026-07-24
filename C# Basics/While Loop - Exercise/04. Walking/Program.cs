using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;
            string input;
            while ((input = Console.ReadLine()) != "Going home")
            {
                int stepsDone = int.Parse(input);
                steps += stepsDone;
                if (steps >= 10000)
                    break;
            }
            if (input == "Going home")
            {
                steps += int.Parse(Console.ReadLine());
            }
            if (steps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10000} steps over the goal!");
            }
            else if (steps < 10000)
            {
                Console.WriteLine($"{10000 - steps} more steps to reach goal.");
            }
        }
    }
}
