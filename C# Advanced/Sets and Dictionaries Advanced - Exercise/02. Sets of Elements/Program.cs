namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lenght = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> commonElements = new HashSet<int>();

            for (int i = 0; i < lenght[0]; i++)
            {
                int element = int.Parse(Console.ReadLine());
                firstSet.Add(element);
            }

            for (int i = 0; i < lenght[1]; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (firstSet.Contains(element))
                {
                    commonElements.Add(element);
                }
            }

            foreach (int element in firstSet)
            {
                if (commonElements.Contains(element))
                {
                    Console.Write(element + " ");
                }
            }

        }
    }
}