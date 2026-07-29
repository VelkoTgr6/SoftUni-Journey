using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        //private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }


        public string Size { get;private set; }

        public double Price 
        {
            get { return price; } 
            private set
            {
                if (Size=="Large")
                {
                    price = value;
                }
                else if (Size=="Middle")
                {
                    price= (2.0 / 3.0) * value;
                }
                else if (Size=="Small")
                {
                    price = (1.0 / 3.0) * value;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
