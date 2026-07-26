namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]input=Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack=new Stack<int>();
            foreach (var item in input)
            {
                stack.Push(item);
            }
            string command;
            while ((command=Console.ReadLine().ToLower())!="end")
            {
                string[] arrComnd = command.ToLower().Split();
                if (arrComnd[0] == "add")
                {
                    int[] numbers = arrComnd.Skip(1).Select(int.Parse).ToArray();
                    foreach (var item in numbers)
                    {
                        stack.Push(item);
                    }
                }
                else if (arrComnd[0] == "remove")
                {
                    int n = int.Parse(arrComnd[1]);
                      while (n>0 && n < stack.Count)
                        {
                            stack.Pop();
                            n--;
                        }
                    
                }
            }
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}