namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numberCounts.ContainsKey(number))
                {
                    numberCounts[number]++;
                }
                else
                {
                    numberCounts[number] = 1;
                }
            }

            int evenOccurrenceNumber = 0;
            foreach (var kvp in numberCounts)
            {
                if (kvp.Value % 2 == 0)
                {
                    evenOccurrenceNumber = kvp.Key;
                    break;
                }
            }

            Console.WriteLine(evenOccurrenceNumber);
        }

    }
    }
