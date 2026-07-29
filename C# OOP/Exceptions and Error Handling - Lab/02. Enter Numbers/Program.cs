using System.Diagnostics.Metrics;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static int ReadNumber(int start, int end)
        {
            int number;
            string input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                throw new FormatException("Invalid Number!");
            }
            else if (number <= start || number >= end)
            {
                throw new ArgumentException();
            }


            return number;
        }

        static void Main()
        {
            int start = 1;
            int end = 100;
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                try
                {
                    numbers[i] = ReadNumber(start, end);
                    start = numbers[i];
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Your number is not in range {0} - {1}!", start, end);
                    i--;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}