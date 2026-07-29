using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.CocktailTypes
{
    public class Hibernation : Cocktail
    {
        private const double forLargePrice = 10.50;
        public Hibernation(string name, string size) : base(name, size, forLargePrice)
        {
        }
    }
}
