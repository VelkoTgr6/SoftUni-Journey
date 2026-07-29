using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Rogue : Hero
    {
        private const int power= 80;
        public Rogue(string name) : base(name, power)
        {

        }
        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {Power} damage";
        }
    }
}
