using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            if (num > num2)
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine(num2);
            }
        }
    }
}
