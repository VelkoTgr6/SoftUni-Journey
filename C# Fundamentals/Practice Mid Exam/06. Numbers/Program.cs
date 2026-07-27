namespace _06._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            double avarage=input.Average();
            int counter = 1;
            foreach (var item in input.OrderByDescending(x=>x))
            {
                if (counter > 5)
                    break;
                
                else if (item > avarage)
                     {
                    Console.Write(item+" ");
                    counter++;
                     }
                else if(input.Count==1)
                {
                    Console.WriteLine("No");
                }
                
            }
        }
    }
}