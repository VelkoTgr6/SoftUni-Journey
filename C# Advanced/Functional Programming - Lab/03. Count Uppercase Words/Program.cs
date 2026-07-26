using Microsoft.VisualBasic;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Where(w => w.StartsWith(char.ToUpper(w[0]))).ToList();
            Console.WriteLine(String.Join("\n", input));
        }
    }
}