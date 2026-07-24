using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                Console.WriteLine(input);
                input = Console.ReadLine();
            }
        }
    }
}
