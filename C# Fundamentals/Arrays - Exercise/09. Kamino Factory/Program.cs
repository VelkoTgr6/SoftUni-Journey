using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int lss = new int[lenght];
            string input = "";

            while ((input=Console.ReadLine())!="Clone Them!")
            {
                int[] dna = input
                        .Split((new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }
          
        }
    }
}
