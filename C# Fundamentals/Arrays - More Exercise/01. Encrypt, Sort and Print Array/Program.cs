using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumConsonant = 0;
            int sumVowel = 0;
            int[]arraySums = new int[n];
            int sum = 0;

            for (int i = 0; i < n ; i++)
            {
                string Name = Console.ReadLine();

                for (int j = 0; j < Name.Length; j++)
                {
                    int currentLetter = Name[j];
                    if (currentLetter == 97 || currentLetter == 101 || currentLetter == 105 || currentLetter == 111 || currentLetter == 117
                        || currentLetter == 65 || currentLetter == 69 || currentLetter == 73 || currentLetter == 79 || currentLetter == 85)
                    { sumVowel += currentLetter * Name.Length; }
                    else
                        sumConsonant += currentLetter / Name.Length;
                }
                sum = sumConsonant + sumVowel;
                arraySums[i] = sum;

                sumVowel = 0;
                sumConsonant = 0;
                sum = 0;
            }
            Array.Sort(arraySums);
            for (int i = 0; i < arraySums.Length; i++)
            {
                Console.WriteLine(arraySums[i]);
            }
        }
    }
}

