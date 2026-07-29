using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models.Players
{
    public class CenterBack : Player
    {
        public const double initRating = 4;
        private const double increaseValue = 1.25;
        private const double decreaseValue = 0.75;
        public CenterBack(string name) : base(name, initRating)
        {

        }
        public override void IncreaseRating()
        {
            if (Rating < 10)
            {
                Rating += 1;
            }
        }
        public override void DecreaseRating()
        {
            if (Rating > 1)
            {
                Rating -= 1;
            }
        }
    }
}
