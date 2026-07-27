namespace _04._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var efficiency = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                int command = int.Parse(Console.ReadLine());
                efficiency.Add(command);
            }
            int countPeople = int.Parse(Console.ReadLine());
            int counter = 1;
            int sumEfficiency = efficiency.Sum();
            while (countPeople>=0)
            {
                if (counter % 4 == 0)
                {
                    counter++;
                    continue;
                }
                if (countPeople - sumEfficiency <= 0)
                    break;

                countPeople -= sumEfficiency;
                counter++;
                
            }
            Console.WriteLine($"Time needed: {counter}h.");
        }
    }
}