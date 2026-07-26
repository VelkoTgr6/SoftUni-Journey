namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numbersPush = NSX[0];
            int numbersPop = NSX[1];
            int numberFind = NSX[2];

            int[]numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i <numbersPush; i++)
            {
                stack.Push(numbers[i]);

            }
            for (int j = 0; j <numbersPop ; j++)
            {
                stack.Pop();
            }
            if (stack.Count > 0)
            {
                if (stack.Contains(numberFind))
                {
                    Console.WriteLine("true");
                }
                else if (!stack.Contains(numberFind))
                {
                    //stack.OrderBy(x => x);
                    Console.WriteLine(stack.MinBy(x => x));
                }
            }
            else 
            {
                Console.WriteLine("0");
            }
            



        }
    }
}