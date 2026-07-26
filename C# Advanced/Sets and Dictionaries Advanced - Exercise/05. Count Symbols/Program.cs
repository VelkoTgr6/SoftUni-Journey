namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char,int>words=new SortedDictionary<char,int>();
            string input = Console.ReadLine();
            
            for (int i = 0; i < input.Length; i++)
            {
                if (words.ContainsKey(input[i]))
                {
                    words[input[i]]+=1;
                    continue;
                }
                words.Add(input[i], 1);
            }
            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key.ToString()}: {item.Value} time/s");
            }
        }
    }
}