using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> list2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int iterations = Math.Max(list1.Count, list2.Count);
  
            List<int> resultList = new List<int>();

            for (int i = 0; i <iterations; i++)
            {
                if(i<list1.Count)
                resultList.Add(list1[i]);
                if(i<list2.Count)
                resultList.Add(list2[i]);
            }
            Console.WriteLine(string.Join(" ", resultList));

        }
    }
}
