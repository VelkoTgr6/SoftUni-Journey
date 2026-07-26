namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);

            foreach (var item in orders)
            {
                if (quantity-item>=0)
                {
                    quantity -= item;
                    queue.Dequeue();
                }
            }
            Console.WriteLine(orders.Max());
            if (queue.Any())
            {
                
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}