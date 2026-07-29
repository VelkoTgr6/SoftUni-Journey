using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models.FishTypes
{
    public class DeepSeaFish : Fish
    {
        private const int _timeToCatch = 180;
        public DeepSeaFish(string name, double points) : base(name, points, _timeToCatch)
        {
        }
    }
}
