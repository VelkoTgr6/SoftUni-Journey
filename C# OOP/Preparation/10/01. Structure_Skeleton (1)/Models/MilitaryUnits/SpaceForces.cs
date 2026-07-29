using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double _cost = 11;
        public SpaceForces() : base(_cost)
        {
        }
    }
}
