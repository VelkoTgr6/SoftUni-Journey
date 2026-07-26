namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Queue<string> names = new Queue<string>();
            while ((command=Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    while(names.Any())
                    {
                        Console.WriteLine(names.Dequeue());
                        
                    }
                    continue;
                }
                names.Enqueue(command);
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}