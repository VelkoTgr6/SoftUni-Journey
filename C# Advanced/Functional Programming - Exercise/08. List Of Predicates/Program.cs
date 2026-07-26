namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, List<int>, List<int>> operaFunc = (end, dividers) =>
            {
                List<int> result = new();
                for (int i = 1; i <= end; i++)
                {
                    foreach (var number in dividers)
                    {
                        if (i % number == 0)
                        {
                            result.Add(i);
                        }
                    }
                }
                return result;
            };

            int end = int.Parse(Console.ReadLine());
            List<int>dividers=Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(String.Join(" ", operaFunc(end, dividers)));
        }
    }
}