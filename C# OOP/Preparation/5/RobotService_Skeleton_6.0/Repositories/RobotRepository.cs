using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private  List<IRobot> robots;
        public RobotRepository() 
        {
            robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(s => s.InterfaceStandards.Any(y=>y==interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()=>robots.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            return robots.Remove(robots.FirstOrDefault(s => s.Model == typeName));
        }
    }
}
