using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while(true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                    break;
                string[] split =command.Split();
                switch (split[0])
                {
                    case "Add":
                        int numbAdd = int.Parse(split[1]);
                        numbers.Add(numbAdd);
                        break;
                    case "Remove":
                        int numbRemove= int.Parse(split[1]);
                        numbers.Remove(numbRemove);
                        break;
                    case "RemoveAt":
                        int indexRemove= int.Parse(split[1]);
                        numbers.RemoveAt(indexRemove);
                        break;
                    case "Insert":
                        int numbInsert = int.Parse(split[1]);
                        int indexInsert = int.Parse(split[2]);
                        numbers.Insert(indexInsert,numbInsert);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
