namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,int>> clothes = new Dictionary<string, Dictionary<string,int>>();
            int n = int.Parse(Console.ReadLine());
            string[] separators = { " -> ", "," };
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(separators,StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                string color = input[0];
                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string,int>());
                   
                    for (int j = 1; j < input.Length; j++)
                    {
                        if (!clothes[color].ContainsKey(input[j]))
                        {
                            clothes[color].Add(input[j],0);
                        }
                        clothes[color][input[j]]+=1;
                    }
                }
                else
                {
                    for (int j = 1; j < input.Length; j++)
                    {
                        if (!clothes[color].ContainsKey(input[j]))
                        {
                            clothes[color].Add(input[j], 0);
                        }
                        clothes[color][input[j]] += 1;
                    }
                }
            }
            string[] found = Console.ReadLine().Split();
            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key == found[0] && cloth.Key == found[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }

            }
        }
    }
}