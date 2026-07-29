using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        private WeaponRepository weapons;
        private UnitRepository units;

        public Controller()
        {
            planets = new PlanetRepository();
            weapons = new WeaponRepository();
            units = new UnitRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit unit = null;
            var planet=planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(SpaceForces) &&
                unitTypeName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            else if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,planetName));
            }
            else
            {
                
                if (unitTypeName == nameof(AnonymousImpactUnit))
                {
                    unit = new AnonymousImpactUnit();
                    planet.Spend(unit.Cost);
                }
                else if (unitTypeName == nameof(SpaceForces))
                {
                    unit = new SpaceForces();
                    planet.Spend(unit.Cost);
                }
                else if (unitTypeName== nameof(StormTroopers))
                {
                    unit = new StormTroopers();
                    planet.Spend(unit.Cost);
                }
                planet.AddUnit(unit);
                
                return string.Format(OutputMessages.UnitAdded ,unitTypeName, planetName);
            }

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException( string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (planet.Weapons.Any(u => u.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            else if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            else
            {
                IWeapon weapon = null;
               
                if (weaponTypeName == nameof(BioChemicalWeapon))
                {
                    weapon = new BioChemicalWeapon(destructionLevel);
                    planet.Spend(weapon.Price);
                }
                else if (weaponTypeName == nameof(NuclearWeapon))
                {
                    weapon = new NuclearWeapon(destructionLevel);
                    planet.Spend(weapon.Price);
                }
                else if (weaponTypeName == nameof(SpaceMissiles))
                {
                    weapon = new SpaceMissiles(destructionLevel);
                    planet.Spend(weapon.Price);
                }
                planet.AddWeapon(weapon);
              
                return string.Format(OutputMessages.WeaponAdded, planetName,weaponTypeName);
            }
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet;
            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            else 
            {
                planet=new Planet(name, budget);
                planets.AddItem(planet);
                return string.Format(OutputMessages.NewPlanet, name);
            }
        }

        public string ForcesReport()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var planet1 = planets.FindByName(planetOne);
            var planet2=planets.FindByName(planetTwo);

            if (planet1.MilitaryPower==planet2.MilitaryPower)
            {
                if(planet1.Weapons.Where(w=>w.GetType().Name == nameof(NuclearWeapon)) != null)
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet1.Profit(planet2.Budget / 2);
                    double forcesCost = planet2.Army.Sum(u=>u.Cost);
                    double weaponsPrice = planet2.Weapons.Sum(w => w.Price);
                    planet1.Profit(forcesCost + weaponsPrice);
                    planets.RemoveItem(planetTwo);

                    return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else if (planet2.Weapons.Where(w => w.GetType().Name == nameof(NuclearWeapon)) != null)
                {
                    planet2.Spend(planet2.Budget / 2);
                    planet2.Profit(planet1.Budget / 2);
                    double forcesCost = planet1.Army.Sum(u => u.Cost);
                    double weaponsPrice = planet1.Weapons.Sum(w => w.Price);
                    planet2.Profit(forcesCost + weaponsPrice);
                    planets.RemoveItem(planetOne);

                    return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
               //  else if (planet1.Weapons.Where(w => w.GetType().Name == nameof(NuclearWeapon)) != null &&
               //     planet2.Weapons.Where(w => w.GetType().Name == nameof(NuclearWeapon)) != null)
               // {
               //     planet1.Spend(planet1.Budget / 2);
               //     planet2.Spend(planet2.Budget / 2);
               //
               //     return string.Format(OutputMessages.NoWinner);
               // }

                planet1.Spend(planet1.Budget / 2);
                planet2.Spend(planet2.Budget / 2);

                return string.Format(OutputMessages.NoWinner);
            }
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                planet1.Spend(planet1.Budget / 2);
                planet1.Profit(planet2.Budget / 2);
                double forcesCost = planet2.Army.Sum(u => u.Cost);
                double weaponsPrice = planet2.Weapons.Sum(w => w.Price);
                planet1.Profit(forcesCost + weaponsPrice);
                planets.RemoveItem(planetTwo);

                return string.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }
            else 
            {
                planet2.Spend(planet2.Budget / 2);
                planet2.Profit(planet1.Budget / 2);
                double forcesCost = planet1.Army.Sum(u => u.Cost);
                double weaponsPrice = planet1.Weapons.Sum(w => w.Price);
                planet2.Profit(forcesCost + weaponsPrice);
                planets.RemoveItem(planetOne);

                return string.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }
            else
            {
                planet.Spend(1.25);
                planet.TrainArmy();
                return string.Format(OutputMessages.ForcesUpgraded, planetName);
            }
        }
    }
}
