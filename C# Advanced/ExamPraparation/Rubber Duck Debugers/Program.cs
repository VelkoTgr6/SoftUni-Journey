namespace Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int>times=new(Console.ReadLine().Split().Select(int.Parse));
            Stack<int>tasks=new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int dartVaderDuck = 0;
            int thorDuck= 0;
            int bigBlueDuck = 0;
            int smallYellowDuck = 0;

            while(times.Any()&&tasks.Any())
            {
                int time=times.Peek();
                int task = tasks.Peek();
                int value=time*task;
                if(value > 240)
                {
                    tasks.Pop();
                    tasks.Push(task-2);
                    times.Dequeue();
                    times.Enqueue(time);
                    continue;
                }
                if (value >= 0 && value <= 60)
                {
                    dartVaderDuck++;
                    times.Dequeue();
                    tasks.Pop();
                }
                else if (value >= 61 && value<=120)
                {
                    thorDuck++;
                    times.Dequeue();
                    tasks.Pop();
                }
                else if(value >=121 && value <= 180)
                {
                    bigBlueDuck++;
                    times.Dequeue();
                    tasks.Pop();
                }
                else 
                { 
                    smallYellowDuck++;
                    times.Dequeue();
                    tasks.Pop();
                }
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {dartVaderDuck}");
            Console.WriteLine($"Thor Ducky: {thorDuck}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueDuck}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowDuck}");
        }
    }
}