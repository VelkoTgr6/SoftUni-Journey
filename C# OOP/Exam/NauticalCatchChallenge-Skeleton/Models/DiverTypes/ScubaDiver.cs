using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.DiverTypes
{
    public class ScubaDiver : Diver
    {
        private const int _oxygenLevel = 120;
        public ScubaDiver(string name) : base(name, _oxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round((double)TimeToCatch, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = _oxygenLevel;
        }
    }
}
