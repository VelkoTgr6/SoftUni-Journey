using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatString(input, n));
        }
        private static string RepeatString(string input, int n)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i <n; i++)
                result.Append(input);
            return result.ToString();
        }
    }
}
