namespace _03._Magic_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var deck = new List<string>(Console.ReadLine().Split(":").ToList());
            var newDeck = new List<string>();
            string command;
            while ((command = Console.ReadLine()) != "Ready")
            {
                if(command =="Shuffle deck")
                {
                    newDeck.Reverse();
                    continue;
                }
                string[] operation = command.Split().ToArray();
                
                switch (operation[0])
                {
                    case "Add":
                        if (deck.Contains(operation[1]))
                        {
                            newDeck.Add(operation[1]);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Insert":
                        if (deck.Contains(operation[1]) && newDeck.Count() >= int.Parse(operation[2]))
                        {
                            newDeck.Insert(int.Parse(operation[2]), operation[1]);
                        }
                        else
                        {
                             Console.WriteLine("Error!");
                         }
                         break;
                     case "Remove":
                        if (newDeck.Contains(operation[1]))
                        {
                            newDeck.Remove(operation[1]);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;
                    case "Swap":
                        string temp = operation[1];
                        int index1 = newDeck.IndexOf(operation[1]);
                         int index2 = newDeck.IndexOf(operation[2]);
                         newDeck[index1] = operation[2];
                         newDeck[index2] = temp;
                        break;
                   //case "Shuffle deck":
                   //    newDeck.Reverse();
                   //    break;

                    default:
                        break;
                }
            }
                Console.WriteLine(string.Join(" ", newDeck));
            
        }
    }
}