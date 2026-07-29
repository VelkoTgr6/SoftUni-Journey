using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    internal class Topping
    {
        private const double baseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> typesToppingCalories;

        private string toppingType;
        private double toppingGrams;

        public Topping(string toppingType, double toppingGrams)
        {
            typesToppingCalories = 
                new Dictionary<string, double> { { "meat",1.2},{"veggies",0.8 },{ "cheese",1.1},{ "sauce",0.9} };

            ToppingType = toppingType;
            ToppingGrams = toppingGrams;
        }
        public double Calories
        {
            get
            {
                double toppingCalorieModifier = typesToppingCalories[ToppingType.ToLower()];
                return baseCaloriesPerGram*ToppingGrams*toppingCalorieModifier;
            }
        }
        public string ToppingType {  get=> toppingType;
            private set
            {
                if(!typesToppingCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType= value;
            }
        }
        public double ToppingGrams { get=> toppingGrams;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }
                toppingGrams= value;
            }
        }
    }
}
