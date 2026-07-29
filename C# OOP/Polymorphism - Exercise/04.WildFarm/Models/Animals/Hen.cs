using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplayer = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier => HenWeightMultiplayer;

        protected override IReadOnlyCollection<Type> PreferredFoodTypes 
            => new HashSet<Type> { typeof(Fruit), typeof(Meat),typeof(Seeds),typeof(Vegetable) };

        public override string AskFood()
        {
            return "Cluck";
        }
    }
}
