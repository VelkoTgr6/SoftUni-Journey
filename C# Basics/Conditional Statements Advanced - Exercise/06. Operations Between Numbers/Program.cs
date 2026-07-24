using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());
            char character = char.Parse(Console.ReadLine());
            double endresult = 0;


            if (character == '+')
            {
                endresult = n1 + n2;
                if (endresult % 2 == 0)
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult} - odd");
                }
            }
            else if (character == '-')
            {
                endresult = n1 - n2;
                if (endresult % 2 == 0)
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult} - odd");
                }
            }
            else if (character == '*')
            {
                endresult = n1 * n2;
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else if (endresult % 2 == 0)
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult} - odd");
                }
            }
            else if (character == '/')
            {
                endresult = n1 / n2;
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult:f2}");
                }
            }
            else if (character == '%')
            {
                endresult = n1 % n2;
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {character} {n2} = {endresult}");
                }
            }
        }
    }
}
