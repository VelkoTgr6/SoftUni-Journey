using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] command=Console.ReadLine().Split(" ").ToArray();
            var products = new Dictionary<string, List<decimal>>();
          
            while (command[0]!="buy")
            {
                string prod = command[0];
                decimal price = decimal.Parse(command[1]);
                int quantity = int.Parse(command[2]);

                if (!products.ContainsKey(command[0]))
                {//create
                    products.Add(prod,new List<decimal>());
                    products[prod].Add(price);
                    products[prod].Add(quantity);
                    
                }
                else
                {
                    if (price!=products[prod][0])
                    {
                        products[prod][0] = price;
                        products[prod][1]+=quantity;
                    }
                   
                }

                command = new string[3];
                command = Console.ReadLine().Split(" ").ToArray();

            }
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Aggregate((a, x) => a * x)}");
            
            }
//Beer 2.20 100
//IceTea 1.50 50
//NukaCola 3.30 80
//Water 1.00 500
//buy 


        }
    }
}

