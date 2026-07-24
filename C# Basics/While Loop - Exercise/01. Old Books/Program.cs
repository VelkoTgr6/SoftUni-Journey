using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookSearching = Console.ReadLine();
            int cycles = 0;
            string input = Console.ReadLine();
            while (input != "No More Books")
            {
                if (bookSearching == input)
                {
                    break;
                }
                cycles++;
                input = Console.ReadLine();
            }

            if (bookSearching == input)
            {
                Console.WriteLine($"You checked {cycles} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {cycles} books.");
            }
        }
    }
}
