using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers.RemoveAll(n => n < 0);
            if (numbers.Count == 0)
                Console.WriteLine("empty");
            else
                numbers.Reverse();
                Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
