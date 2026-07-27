using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            
            for (int i = 0; i < numbers.Count; i++)
            {
                int nextIndext = 0;
                if (i + 1 > numbers.Count - 1)
                    break;
                else
                    nextIndext = i + 1;

                if(numbers[i]==numbers[nextIndext])
                {
                    numbers[i] += numbers[nextIndext];
                    numbers.RemoveAt(nextIndext);
                    i = -1;
                }
            }
            
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}       
