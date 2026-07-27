namespace _03._Messages_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            var messages = new Dictionary<string, List<int>>();
            //var receivedMs=new Dictionary<string,int>
            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] array = command.Split("=").ToArray();
                switch (array[0])
                {
                    case "Add":
                        if (!messages.ContainsKey(array[1]))
                        {
                            messages.Add(array[1], new List<int>());
                            messages[array[1]].Add(int.Parse(array[2]));
                            messages[array[1]].Add(int.Parse(array[3]));
                        }
                        else
                            continue;

                        break;
                    case "Message":
                        string sender = array[1];
                        string receiver = array[2];
                        if (messages.ContainsKey(sender) && messages.ContainsKey(receiver))
                        {
                            messages[sender].Add(1);
                            messages[receiver].Add(1);
                        }
                        if (messages[sender].Sum() >= capacity)
                        {
                            messages.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (messages[receiver].Sum() >= capacity)
                        {
                            messages.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                        break;
                    case "Empty":
                        if (messages.ContainsKey(array[1]))
                        {
                            messages.Remove(array[1]);
                        }
                        else
                            messages.Clear();
                        break;
                    default:
                        break;
                }
            }
           //var ordered = messages.OrderBy(x => x.Value).ToList();

            foreach (var contacts in messages)
            {
                Console.WriteLine($"Users count: {messages.Count()}");
                foreach (var users in messages.OrderByDescending(x=>x.Value.Count))
                {
                    Console.WriteLine($"{users.Key} - {users.Value.Sum()}");
                }
                break;
            }

        }
    }
}
