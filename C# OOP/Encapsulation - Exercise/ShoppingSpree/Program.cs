namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string [] peopleData=Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();
            //string [] productsData= Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries).ToArray();

            
            List<Person>people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                string[] nameMoneyPairs = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var nameMoneyPair in nameMoneyPairs)
                {
                    string[] nameMoney = nameMoneyPair
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Person person = new(nameMoney[0], decimal.Parse(nameMoney[1]));

                    people.Add(person);
                }

                string[] productCostPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var productCostPair in productCostPairs)
                {
                    string[] productCost = productCostPair
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Product product = new(productCost[0], decimal.Parse(productCost[1]));

                    products.Add(product);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ");
                if (command.Length >= 2)
                {
                    string personName = command[0];
                    string productName = command[1];
                    
                        Person person = people.FirstOrDefault(p => p.Name == personName);
                        Product product = products.FirstOrDefault(p => p.Name == productName);

                    if (person is not null && product is not null)
                    {
                        Console.WriteLine(person.BuyProduct(product));
                    }  
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, people));


        }
    }
}