namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,int,bool> isEven = (conditon,number) =>
            {
                if (conditon=="even")
                {
                    return number % 2 == 0;
                }
                else
                {
                    return number % 2 != 0;
                }
                
            };
            Func< int, int,List<int>> generatedRange = (start, end) =>
            {
                List<int> range = new();
                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }
                return range;
            };

            int[]boundries=Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command=Console.ReadLine();
            List<int> numbers = generatedRange(boundries[0], boundries[1]);

            foreach (var number in numbers)
            {
                if (isEven(command,number))
                {
                    Console.Write(number+ " ");
                }
            }
        }
    }
}