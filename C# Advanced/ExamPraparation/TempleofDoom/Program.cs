using System;
using System.Security.Cryptography.X509Certificates;

namespace TempleofDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int>substances = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            List<int>challanges= new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (tools.Any() && substances.Any())
            {
                int tool = tools.Peek();
                int substance = substances.Peek();
                int value = tool * substance;

                if (challanges.Contains(value))
                {
                    tools.Dequeue();
                    substances.Pop();
                    challanges.Remove(value);
                }
                else
                {
                    tools.Dequeue();
                    tools.Enqueue(tool + 1);

                    substances.Pop();
                    substances.Push(substance - 1);
                    if (substance - 1 <= 0)
                    {
                        substances.Pop();
                    }
                }
            }
            if (challanges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                CheckPrint(tools, substances, challanges);
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                CheckPrint(tools, substances, challanges);
            }
            
             static void CheckPrint(Queue<int> queue,Stack<int>stack,List<int>list)
            {
                if (queue.Any())
                {
                    Console.WriteLine($"Tools: {String.Join(", ", queue)}");
                }
                if (stack.Any())
                {
                    Console.WriteLine($"Substances: {String.Join(", ", stack)}");
                }
                if (list.Any())
                {
                    Console.WriteLine($"Challenges: {String.Join(", ", list)}");
                }

            }
        }
    }
}