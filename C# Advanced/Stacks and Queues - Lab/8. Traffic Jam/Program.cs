namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string>cars=new Queue<string>();
            string command;
            int counter = 0;
            while((command=Console.ReadLine())!="end")
            {
                if (command=="green")
                {
                    for (int i = 1; i <=n; i++)
                    {
                        if(cars.Count > 0)
                        {
                            Console.WriteLine(cars.Dequeue()+" passed!");
                            counter++;
                        }
                    }
                    continue;
                }
                cars.Enqueue(command);
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}