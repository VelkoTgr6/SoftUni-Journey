using System.Data;
using System.Text;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> namesInput = Console.ReadLine().Split().ToList();
            string command;
            while ((command=Console.ReadLine())!="Party!")
            {
                string[]tokens=command.Split().ToArray();

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action== "Remove")
                {
                    namesInput.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string>peopleToDouble = namesInput.FindAll(GetPredicate(filter, value));
                    foreach (var person in peopleToDouble)
                    {
                        int index=namesInput.FindIndex(p=>p==person);
                        namesInput.Insert(index, person);

                    }
                }
            }
            if (namesInput.Count>0)
            {
                Console.WriteLine($"{ string.Join(", ", namesInput)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        static Predicate<string>GetPredicate(string filter,string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return n=>n.StartsWith(value);
                case "EndsWith":
                    return n=>n.EndsWith(value);
                case "Length":
                    return n => n.Length == int.Parse(value);
                default:
                    return default;
            }
        }
    }
}