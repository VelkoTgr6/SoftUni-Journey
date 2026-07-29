using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int power = 80;
        public Druid(string name) : base(name, power)
        { 
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
