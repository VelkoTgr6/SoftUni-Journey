namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            HashSet<string> set = new HashSet<string>();
            while ((command=Console.ReadLine())!="END")
            {
                string[] commandArr = command.Split(", ");
                if (commandArr[0] == "IN")
                {
                    set.Add(commandArr[1]);
                }
                else if (commandArr[0]=="OUT")
                {
                    set.Remove(commandArr[1]);
                }
            }
            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}