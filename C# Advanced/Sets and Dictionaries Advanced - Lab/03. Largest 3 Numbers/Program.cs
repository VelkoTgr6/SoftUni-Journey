namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]sorted=Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x=>x).ToArray();
            for (int i = 0; i < 3; i++)
            {
                if(sorted.Length>=3)
                Console.Write($"{sorted[i]} ");

                else
                {
                    Console.WriteLine(String.Join(" ", sorted));
                    break;
                }
            }
        }
    }
}