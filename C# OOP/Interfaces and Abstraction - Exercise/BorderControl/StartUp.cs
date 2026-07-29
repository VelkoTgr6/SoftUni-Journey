using BorderControl.Model;
using BorderControl.Model.Interface;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBuyer> society = new();
           
            int n=int.Parse(Console.ReadLine());
            for (int i = 0; i <n; i++) 
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length==4)
                {
                    IBuyer citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    society.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    society.Add(rebel);
                }
            }
            string input2;
            while ((input2 = Console.ReadLine()) !="End")
            {
                society.FirstOrDefault(society=>society.Name==input2)?.BuyFood();
            }

            Console.WriteLine(society.Sum(s => s.Food));
        }
    }
}