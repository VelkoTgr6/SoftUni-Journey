using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class Goalkeeper : Player
    {
        public const double initRating = 2.5;
        private const double increaseValue = 0.75;
        private const double decreaseValue = 1.25;

        public Goalkeeper(string name) : base(name, initRating)
        {

        }
        public override void IncreaseRating()
        {
            base.Rating += increaseValue;
            if (base.Rating > 10)
            {
                Rating = 10;
            }
        }
        public override void DecreaseRating()
        {
            base.Rating -= decreaseValue;
            if (base.Rating < 1)
            {
                Rating = 1;
            }
        }
    }
}
