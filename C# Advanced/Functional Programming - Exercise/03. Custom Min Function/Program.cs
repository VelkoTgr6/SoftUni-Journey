namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Func<List<int>, int> min = numbers =>
            {
                int min = int.MaxValue;
                foreach (var number in numbers)
                {
                    if (number < min)
                    {
                        min = number;
                    }
                }

                return min;
            };
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(min(input));

        }
    }
}