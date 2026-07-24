using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumb = int.Parse(Console.ReadLine());

            int sum = 0;
            while (sum < inputNumb)
            {
                int currentNumb = int.Parse(Console.ReadLine());
                sum += currentNumb;
            }
            Console.WriteLine(sum);
        }
    }
}
