using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplements
    {
        private const int _interfaceStandard = 20_082;
        private const int _batteryUsage = 5000;
        public LaserRadar() : base(_interfaceStandard, _batteryUsage)
        {
        }
    }
}
