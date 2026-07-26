namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());    
           List<Person> people =new List<Person>();

           for (int i = 0; i < n; i++)
           {
                string[] input = Console.ReadLine().Split(", ");
                people.Add(new Person() { Name = input[0], Age = int.Parse(input[1]) });
           }

           string filterType=Console.ReadLine();
            int ageFilter=int.Parse(Console.ReadLine());
            string formatType=Console.ReadLine();

            Func<Person,bool> filter=GetFilter(filterType, ageFilter);
            people = people.Where(filter).ToList();
            Action<Person> printer = GetPrinter(formatType);  
            foreach (var person in people)
            {
                printer(person);
            }
            Func<Person,bool> GetFilter(string filterType,int age)
            {
                switch (filterType)
                {
                    case "older":return person=>person.Age >=age;
                    case "younger":return person =>person.Age <age;
                    default:
                        return null;
                }
            }
            Action<Person>GetPrinter(string formatType)
            {
                switch(formatType)
                {
                    case "name age":return person => Console.WriteLine($"{person.Name} - {person.Age}");
                    case "age": return person => Console.WriteLine($"{person.Age}");
                    case "name": return person => Console.WriteLine($"{person.Name}");
                    default:
                        return null;
                }
            }
            
        }
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        
    }
}