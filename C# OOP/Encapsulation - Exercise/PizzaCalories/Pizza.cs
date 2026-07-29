using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    internal class Pizza
    {
        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;
         
        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }
       

        public string Name 
        {   
            get=>name;
            private set
            {
                if (string.IsNullOrEmpty(value)||value.Length<1||value.Length>15)
                {
                    throw new ArgumentNullException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough 
        {
            get => dough;
            set => dough = value;
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
        public double TotalCalories
        {
            get
            {
                return Dough.Calories + toppings.Sum(t => t.Calories);
                
            }
        }
        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }

    }
}
