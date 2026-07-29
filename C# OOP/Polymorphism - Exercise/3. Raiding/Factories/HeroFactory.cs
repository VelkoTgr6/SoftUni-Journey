using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string name, string type)
        {
            switch(type)
            {
                case "Paladin":
                    return new Paladin(name);
                    break;
                case "Druid":
                    return new Druid(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }

        
    }
}
