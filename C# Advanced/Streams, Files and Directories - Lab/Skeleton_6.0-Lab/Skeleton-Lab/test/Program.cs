namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());

            for (int i = 1; i <= firstN; i++)
            {
                for (int j = 1; j <= secondN; j++)
                {
                    Console.WriteLine($"{i}.{j}");
                }
            }
        }
    }
}