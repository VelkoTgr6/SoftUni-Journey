using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.CocktailTypes
{
    public class MulledWine : Cocktail
    {
        private const double forLargePrice = 13.50;
        public MulledWine(string name, string size) : base(name, size, forLargePrice)
        {
        }
    }
}
