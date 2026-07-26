namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<string, int> dict  = new Dictionary<string, int>();

            foreach ( var item in input)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                dict[item]++;
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}