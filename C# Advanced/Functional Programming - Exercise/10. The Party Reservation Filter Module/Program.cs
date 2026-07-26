using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            Dictionary<string,Predicate<string>> filters= new Dictionary<string,Predicate<string>>();
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(";").ToArray();

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Add filter")
                {
                    if(!filters.ContainsKey(filter+value))
                    filters.Add(filter + value,GetPredicate(filter,value));
                }
                else
                {
                    filters.Remove(filter + value);
                }
            }
            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }
            Console.WriteLine(String.Join(" ", people));
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return n => n.StartsWith(value);
                case "Ends with":
                    return n => n.EndsWith(value);
                case "Length":
                    return n => n.Length == int.Parse(value);
                case "Contains":
                    return n=>n.Contains(value);
                default:
                    return default;
            }
        }
    }
}