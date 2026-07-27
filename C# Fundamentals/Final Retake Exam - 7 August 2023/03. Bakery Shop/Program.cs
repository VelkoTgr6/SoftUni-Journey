using System.Collections.Generic;

namespace _03._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string,int>();
            string command;
            int totalSold = 0;
            while ((command=Console.ReadLine())!= "Complete")
            {
                string[] commandArr = command.Split();
                string productName = commandArr[2];
                int quantity = int.Parse(commandArr[1]);
                switch (commandArr[0])
                {
                    case "Receive":
                        if (!products.ContainsKey(productName))
                        {
                            if (quantity > 0)
                            {
                                products.Add(productName, quantity);
                            }
                            continue;
                        }
                        if (products.ContainsKey(productName))
                        {
                            products[productName] += quantity;
                        }
                        break;
                    case "Sell":
                        if (!products.ContainsKey(productName))
                        {
                            Console.WriteLine($"You do not have any {productName}.");
                            continue;
                        }
                        if (quantity > products[productName])
                        {
                            Console.WriteLine($"There aren't enough {productName}. You sold the last {products[productName]} of them.");
                            totalSold += products[productName];
                            products.Remove(productName);
                            continue;
                        }
                        if(quantity <= products[productName])
                        {
                            if (products[productName] - quantity <=0)
                            {
                                totalSold += products[productName];
                                Console.WriteLine($"You sold {products[productName]} {productName}.");
                                products.Remove(productName);
                               
                            }
                            else
                            {
                                products[productName] -= quantity;
                                totalSold += quantity;
                                Console.WriteLine($"You sold {quantity} {productName}.");
                            }
                        }
                        break;
                }
            }
           
            foreach (KeyValuePair<string, int> kvp in products)
            {
                string key = kvp.Key;
                int value = kvp.Value;

                Console.WriteLine($"{key}: {value}");
            }   
            Console.WriteLine($"All sold: {totalSold} goods");
        }   
    }
}