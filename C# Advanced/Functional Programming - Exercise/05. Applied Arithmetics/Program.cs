namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,List<int>,List<int>> operations = (command, numbers) =>
            {
                List<int> result = new();
                foreach (var number in numbers)
                {
                    switch (command)
                    {
                        case "add":
                            result .Add(number+1);break;
                        case "multiply":
                            result.Add(number*2);break;
                        case "subtract":
                            result.Add(number - 1);break;
                        
                    }
                }
                return result;
            };

            List<int>input=Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            while ((command=Console.ReadLine())!="end")
            {
                if (command == "print")
                {
                    Console.WriteLine(String.Join(" ", input));
                }
                else
                {
                    input=operations(command,input);
                }
            }

        }
    }
}