using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var words = new Dictionary<string,int>();
            string[]singleWord=input.Select(x=> new string(x, 1)).ToArray();
            int count = 0;

            for (int i = 0; i < singleWord.Length; i++)
            {
                if (singleWord[i] == " ")
                    continue;
                if (!words.ContainsKey(singleWord[i]))
                {
                    count = 1;
                    words.Add(singleWord[i],count);
                    
                   // words[singleWord[i]].Add(count);
                }
                else
                {
                    count = words[singleWord[i]];
                    words[singleWord[i]] = count+1;
                }
            }
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} -> {string.Join(" ",word.Value)}");
            }
            
            

           
            

        }
    }
}
