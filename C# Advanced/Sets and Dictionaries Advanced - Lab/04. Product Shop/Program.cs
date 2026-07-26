using System.Collections.Immutable;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string command;
            while ((command=Console.ReadLine())!="Revision")
            {
                string[] commandArr = command.Split(",");
                string shopName = commandArr[0];
                string product = commandArr[1];
                double price = double.Parse(commandArr[2]);
                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }
                shops[shopName].Add(product, price);

            }
            foreach ( var items in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{items.Key}->");
                foreach (var products in items.Value)
                {
                    Console.WriteLine($"Product:{products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}