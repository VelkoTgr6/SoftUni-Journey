using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    internal class Bus : Vehicle
    {
        private const double IncreasedConsumptionWithPeople = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity)
            : base(fuelQuantity, fuelConsumption, IncreasedConsumptionWithPeople, tankCapacity)
        {
        }
    }
}
