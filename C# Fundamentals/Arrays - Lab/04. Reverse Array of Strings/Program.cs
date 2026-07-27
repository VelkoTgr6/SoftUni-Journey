using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < items.Length/2; i++)
            {
                string temp = items[i];
                items[i] = items[items.Length - i - 1];
                items[items.Length - i - 1] = temp;
            }
            Console.WriteLine(string.Join(" ", items));




        }
    }
}
