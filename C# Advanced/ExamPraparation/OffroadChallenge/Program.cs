namespace OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuelamount = new Stack<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> consumptions = new Queue<int>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> needed = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int counter = 1;
            int reachedAltitudes = 0;



            while (fuelamount.Any() && consumptions.Any())
            {
                int fuel = fuelamount.Peek();
                int consumption = consumptions.Peek();
                int neededV = needed.Peek();
                int value = fuel - consumption;
                

                if (value >= neededV)
                {
                    fuelamount.Pop();
                    consumptions.Dequeue();
                    needed.Dequeue();
                    reachedAltitudes++;
                    Console.WriteLine($"John has reached: Altitude {reachedAltitudes}");
                }
                else
                {
                    //Console.WriteLine($"John did not reach: Altitude {reachedAltitudes++}");
                    break;
                }
               
                

            }
            if (reachedAltitudes<=needed.Count)
            {
                Console.WriteLine($"John did not reach: Altitude {reachedAltitudes + 1}");
                Console.WriteLine("John failed to reach the top.");
                if (reachedAltitudes > 0)
                {
                    Console.WriteLine($"Reached altitudes: Altitude {String.Join(", Altitude ",Enumerable.Range(1,reachedAltitudes))}");
                }
                else
                {
                    Console.WriteLine("John didn't reach any altitude.");
                }
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }

        }
    }
}