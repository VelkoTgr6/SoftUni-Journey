using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        class Order
        {
            public string Customer { get; set; }

            public string Product { get; set; }

            public uint Quantity { get; set; }

            public decimal Price { get; set; }

            public decimal Total()
            {
                return Quantity * Price;
            }
        }
        static void Main(string[] args)
        {
            //List<Order> orders = new List<Order>();
            string input;
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+|\d+\.\d+)\$";
            decimal totalSum = 0;
            while ((input=Console.ReadLine())!= "end of shift")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    Order order = new Order();
                    order.Customer = match.Groups["customer"].Value;//fill the ORDER CLASS from regex input
                    order.Product = match.Groups["product"].Value;
                    order.Quantity = uint.Parse(match.Groups["count"].Value);
                    order.Price = decimal.Parse(match.Groups["price"].Value);

                    Console.WriteLine($"{order.Customer}: {order.Product} - {order.Total():f2}");
                    totalSum += order.Total();
                }
            }
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}