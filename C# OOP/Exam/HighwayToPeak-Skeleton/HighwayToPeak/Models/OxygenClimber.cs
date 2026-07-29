using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int _stamina=10;
        public OxygenClimber(string name) : base(name, _stamina)
        {
        }
        public override void Rest(int daysCount)
        {
            int newStamina = Math.Min(10, Stamina + daysCount);
            SetStamina(newStamina);
        }

        private void SetStamina(int newStamina)
        {
            stamina = newStamina;
        }


    }
}
