namespace Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();
            string line;

            while ((line = Console.ReadLine()) != "exit")
            {
                switch (line)
                {
                    case "start":
                        Task.Run(() => chronometer.Start());
                        break;
                    case "stop":
                         chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        if (chronometer.Laps.Count == 0)
                        {
                            Console.WriteLine("Laps: no laps");
                        }
                        else
                        {
                            Console.WriteLine("Laps:");
                            Console.WriteLine(string.Join(Environment.NewLine, chronometer.Laps));
                        }
                        
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                }
            }
        }

    }
}
