using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            var counts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                string wordLower = word.ToLower();
                if (counts.ContainsKey(wordLower))
                {
                    counts[wordLower]++;
                }
                else
                {
                    counts.Add(wordLower,1);
                }

            }
            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + "");
                }
            }
        }
    }
}
