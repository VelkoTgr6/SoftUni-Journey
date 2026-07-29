using System;

class Program
{
    static void Main(string[] args)
    {
        string[] elements = Console.ReadLine().Split(' ');

        int sum = 0;

        foreach (string element in elements)
        {
            int number;
            if (int.TryParse(element, out number))
            {
                try
                {
                    sum += checked(number);
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
            }
            else
            {
                Console.WriteLine($"The element '{element}' is in wrong format!");
            }
        }

        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}

