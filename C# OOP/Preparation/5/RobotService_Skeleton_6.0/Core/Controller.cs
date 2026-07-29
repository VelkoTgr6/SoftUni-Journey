using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private RobotRepository robots;
        private SupplementRepository supplements;

        public Controller()
        {
            robots=new RobotRepository();
            supplements=new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;   
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            if (typeName == nameof(IndustrialAssistant))
            {
                robot =new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }
            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName,model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;
            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated,typeName);
            }
            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var selectedRobots = this.robots.Models()
                .Where(r => r.InterfaceStandards.Any(i => i == intefaceStandard)).OrderByDescending(y => y.BatteryLevel);
            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }
            var batterySum = selectedRobots.Sum(r => r.BatteryLevel);
            int counter = 0;

            if (batterySum<totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - batterySum);
            }
            foreach (var item in selectedRobots)
            {
                counter++;
                if (counter == 5) 
                { 
                }
            }

        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RobotRecovery(string model, int minutes)
        {
            throw new NotImplementedException();
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var supplement = supplements.Models().FirstOrDefault(x=>x.GetType().Name == supplementTypeName);
            var selectedModels = robots.Models().Where(x => x.Model == model);
            var stillNotUpgraded=selectedModels.Where(r=>r.InterfaceStandards.All(s=>s!=supplement.InterfaceStandard));
            var robotForUpgrade = stillNotUpgraded.FirstOrDefault();

            if (robotForUpgrade != null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }
            robotForUpgrade.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful,model, supplementTypeName);
        }
    }
}
