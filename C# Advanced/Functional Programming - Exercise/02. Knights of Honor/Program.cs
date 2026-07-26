namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            foreach (var name in input)
            {
                Action<string> printer = Print(name);
                printer(name);
            }
            Action<string> Print(string input)
            {
                return n => Console.WriteLine("Sir "+input);

            }
        }
    }
}