namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] NSX = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numbersPush = NSX[0];
            int numbersPop = NSX[1];
            int numberFind = NSX[2];

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numbersPush; i++)
            {
                queue.Enqueue(numbers[i]);

            }
            for (int j = 0; j < numbersPop; j++)
            {
                queue.Dequeue();
            }
            if (queue.Count > 0)
            {
                if (queue.Contains(numberFind))
                {
                    Console.WriteLine("true");
                }
                else if (!queue.Contains(numberFind))
                {
                    //stack.OrderBy(x => x);
                    Console.WriteLine(queue.MinBy(x => x));
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}