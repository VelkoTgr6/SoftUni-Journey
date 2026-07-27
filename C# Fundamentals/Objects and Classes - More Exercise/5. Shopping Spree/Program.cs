using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Shopping_Spree
{
    class Person
    {
        public Person(List<Person> order, List<Person> money, List<Person> bagOfProducts)
        {
            Order = order;
            Money = money;
            BagOfProducts = bagOfProducts;
        }

        public List<Person> Order { get; set; }
        public List<Person> Money { get; set; }
        public List<Person> BagOfProducts { get; set; }
    }
    class Product
    {
       // public Product(List<Product> name, List<Product> cost)
      // {
      //     Name = name;
      //     Cost = cost;
      // }

        public List<Product> Name { get; set; }
        public List<Product> Cost { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string command;

            for (int i = 0; i < 1; i++)
            {
                string[] input = Console.ReadLine().Split(';','=');
                if (i!=1)
                {
                    var member = new Person(input[0], int.Parse(input[1]));
                }
            }
                
            while ((command=Console.ReadLine())!="END")
            {

            }
        }
    }
}
