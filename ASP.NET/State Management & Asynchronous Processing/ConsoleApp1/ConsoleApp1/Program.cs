using System.Security.Principal;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a=int.Parse( Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Thread events=new Thread(() => PrintEvenNumbers(a, b));
            events.Start();
            events.Join();
            Console.WriteLine("Thread finished");

        }

        private static void PrintEvenNumbers(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
