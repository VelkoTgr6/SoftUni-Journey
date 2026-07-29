using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class ForwardWing : Player
    {  
        public const double initRating = 5.5;
        private const double increaseValue = 1.25;
        private const double decreaseValue = 0.75;
        public ForwardWing(string name) : base(name, initRating)
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
