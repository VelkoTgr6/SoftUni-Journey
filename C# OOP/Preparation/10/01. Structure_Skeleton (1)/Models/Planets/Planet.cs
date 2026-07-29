using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name 
        {
            get { return name; } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName).TrimEnd());
                }
                name = value;
            }
        }
        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount).TrimEnd());
                }
                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => army;

        public IReadOnlyCollection<IWeapon> Weapons => weapons;

        private double CalculateMilitaryPower()
        {
            double totalAmount = Army.Sum(u => u.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel);
            if (army.Any(u => u is AnonymousImpactUnit))
            {
                totalAmount *= 1.3; 
            }
            if (weapons.Any(w=>w is NuclearWeapon))
            {
                totalAmount *= 1.45;
            }
            return Math.Round(totalAmount,3);
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append("--Forces: ");
            if (army.Count==0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                var unitTypeNames = army.Select(w => w.GetType().Name);
                sb.AppendLine(string.Join(", ", unitTypeNames));
            }
            sb.Append("--Combat equipment: ");
            if (weapons.Count==0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                var weaponTypeNames = weapons.Select(w => w.GetType().Name);
                sb.AppendLine(string.Join(", ", weaponTypeNames));
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();

        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        { 
            if (Budget-amount < 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.UnsufficientBudget).TrimEnd());
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
