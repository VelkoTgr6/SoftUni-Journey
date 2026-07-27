using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int originalLenght = list.Count ;
            for (int i = 0; i < originalLenght/2; i++)
            {
                list[i] += list[list.Count - 1];
                list.RemoveAt(list.Count - 1);

            }
            Console.WriteLine(string.Join(" ", list));

        }
    }
}
