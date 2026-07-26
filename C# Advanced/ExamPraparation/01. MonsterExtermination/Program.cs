using System.Linq;

namespace _01._MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Queue<int> monsters = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Stack<int> strikes = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            int killed = 0;

            while (monsters.Any() && strikes.Any())
            {
                int armour = monsters.Peek();
                int strike = strikes.Peek();

                if (armour <= strike)
                {
                    killed++;
                    strike -= armour;
                    if (strike == 0)
                    {
                        strikes.Pop();
                        monsters.Dequeue();
                    }
                    else
                    {
                        monsters.Dequeue();
                        if (strikes.Count == 1)
                        {
                            strikes.Pop();
                            strikes.Push(strike);
                            continue;
                        }
                        else
                        {
                            strikes.Pop();
                            int tempStrike = strike;
                            strikes.Push(strikes.Pop() + tempStrike);
                        }

                    }
                }
                else
                {
                    armour -= strike;
                    strikes.Pop();
                    monsters.Dequeue();
                    monsters.Enqueue(armour);
                }
            }
            if (!monsters.Any())
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if(!strikes.Any())
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            Console.WriteLine($"Total monsters killed: {killed}");
        }
    }

}