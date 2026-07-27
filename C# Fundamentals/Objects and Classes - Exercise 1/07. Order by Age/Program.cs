using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
        class Program
        {
            static void Main(string[] args)
            {
                string command;
                List<Person> people = new List<Person>();
                while ((command=Console.ReadLine())!="End")
                {
                    string[] input = command.Split(" ");
                    string name = input[0];
                    string iD = input[1];
                    int age = int.Parse(input[2]);
                    Person person = new Person(name, iD, age);
                    Person sameId = people.Find(people => people.ID == iD);
                    if (sameId!=null)
                    {
                        people.Remove(sameId);
                        people.Add(person);        
                    }
                    else
                    people.Add(person);
                }
                foreach (Person person in people.OrderBy(person=>person.Age))
                {
                    Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
                }
            }
        }
    }
}
