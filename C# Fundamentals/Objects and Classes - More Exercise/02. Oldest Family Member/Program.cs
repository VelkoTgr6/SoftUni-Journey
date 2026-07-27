using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public Person() { }
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }
}

public class Family
{
    public Family()
    {
        this.OrderPersons = new List<Person>();
    }

    public List<Person> OrderPersons { get; set; }

    public void AddMember(Person member)
    {
        OrderPersons.Add(member);
    }

    public Person GetOldestMember()
    {
        // var currentPersona = new Person { Name = "one", Age = -1 };
        var oldestPerson = OrderPersons.OrderByDescending(x => x.Age).FirstOrDefault();

        Console.WriteLine("{0} {1}", oldestPerson.Name, oldestPerson.Age);
        return oldestPerson;
        //return currentPersona;
    }

} // end class Family

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var currentFamily = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split();

            var member = new Person(input[0], int.Parse(input[1]));

            currentFamily.AddMember(member);
        } // end for

        if (currentFamily.OrderPersons.Count > 0)
        {
            currentFamily.GetOldestMember();
        }

    }
}