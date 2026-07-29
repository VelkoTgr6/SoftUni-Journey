using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplements
    {
        private const int _interfaceStandard = 10_045;
        private const int _batteryUsage = 10_000;
        public SpecializedArm() : base(_interfaceStandard, _batteryUsage)
        {
        }
    }
}
