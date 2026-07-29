using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingSpree
{
    internal class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        public string BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                bagOfProducts.Add(product);
                return $"{Name} bought {product.Name}";
            }
            else
            {
                return $"{Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            else
            {
                string products = string.Join(", ", bagOfProducts.Select(p => p.Name));
                return $"{Name} - {products}";
            }
        }

        public string Name { get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money { get {  return money; } 
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                else
                {
                    money = value;
                }
            }
        }

    }
}
