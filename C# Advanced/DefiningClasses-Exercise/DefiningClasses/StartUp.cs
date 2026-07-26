using DefiningClasses;
using System;
using System.Diagnostics.Contracts;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[]arg)
        {
            int n=int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
           
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                people.Add( new Person(input[0], int.Parse(input[1])));
            }
            List<Person>older30=people.Where(p=>p.Age>30).OrderBy(p=>p.Name).ToList();
           
            
            foreach (Person person in older30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

            
        }
    }
}