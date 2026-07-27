using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());

            for (int i = 0; i <n; i++)
            {
                char firschar=(char)('a'+i);

                for (int j = 0; j <n; j++)
                {
                    char firschar2 = (char)('a' + j);

                    for (int k = 0; k <n; k++)
                    {
                        char firschar3 = (char)('a' + k);
                        Console.Write($"{firschar}{firschar2}{firschar3}");
                        Console.WriteLine();
                    }
                    

                }
                

            }
        }
    }
}
