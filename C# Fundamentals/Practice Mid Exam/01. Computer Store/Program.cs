using System.Diagnostics;

namespace _01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command ="";
            decimal price=0;
            //decimal pricePercent = price * (decimal)0.2;
            while ((command=Console.ReadLine()) != "special" || command != "regular")
            {
                if (command == "special" || command == "regular")
                    break;
                decimal input = decimal.Parse(command);
                if (input > 0)
                    price += input;
                else
                {
                    Console.WriteLine("Invalid order!");
                    continue;
                }

            }
            decimal pricePercent = price * (decimal)0.2;

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {price}$");
            Console.WriteLine($"Taxes: {pricePercent}$");
            Console.WriteLine("-----------");
            if(command == "special")
            Console.WriteLine($"Total price: {(price + pricePercent)*(decimal)0.9}$");
            else
                Console.WriteLine($"Total price: {price + pricePercent:f2}$");
        }
    }
}