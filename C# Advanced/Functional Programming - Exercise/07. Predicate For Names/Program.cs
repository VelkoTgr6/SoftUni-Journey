namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, List<string>, List<string>> namesFunc = (lenght, names) =>
            {
                List<string> result = new();
                foreach (var name in names)
                {
                    if (name.Length <= lenght)
                    {
                        result.Add(name);
                        Console.WriteLine(name);
                    }

                }
                
                return result;
            };
            int lenght = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            namesFunc(lenght,names);

        }
    }
}