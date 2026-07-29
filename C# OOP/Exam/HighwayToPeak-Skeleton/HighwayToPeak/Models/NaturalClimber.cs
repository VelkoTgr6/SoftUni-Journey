using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int _stamina = 6;
        public NaturalClimber(string name) : base(name, _stamina)
        {
        }

        public override void Rest(int daysCount)
        {
            // NaturalClimbers recover 2 units of stamina for every day of rest
            int newStamina = Math.Min(10, Stamina + 2 * daysCount);
            SetStamina(newStamina);
        }

        private void SetStamina(int newStamina)
        {
            // Set the stamina using the private field
            stamina = newStamina;
        }
    }
    }
