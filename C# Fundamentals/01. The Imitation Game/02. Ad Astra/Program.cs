using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Products
    {
        public string Name { get; set; }

        public string Expiration { get; set; }

        public int Calories { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<product>\w+\s\w+|\w+)\|(?<expiration>\d+/\d+/\d+)\|(?<calories>\d+)\||#(?<product>\w+\s\w+|\w+)#(?<expiration>\d+/\d+/\d+)#(?<calories>\d+)#";
            string input = Console.ReadLine();
            int caloriesSum = 0;
            List<Products>products = new List<Products>();


            foreach (Match match in Regex.Matches(input,pattern))
            {
                Products product = new Products();
                product.Name = match.Groups["product"].Value;
                product.Expiration = match.Groups["expiration"].Value;
                product.Calories =int.Parse(match.Groups["calories"].Value);
                caloriesSum += product.Calories;
                products.Add(product);
            }
            caloriesSum /= 2000;
            Console.WriteLine($"You have food to last you for: {caloriesSum} days!");
            foreach (Products item in products)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.Expiration}, Nutrition: {item.Calories}");
            }
        }

    }
}