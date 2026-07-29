using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        private ClimberRepository climbers;
        private PeakRepository peaks;
        private BaseCamp baseCamp;

        public Controller()
        {
            climbers = new ClimberRepository();
            peaks = new PeakRepository();
            baseCamp = new BaseCamp();
        }


        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak peak=peaks.Get(name);
            if (peak!=null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }
            else if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel !="Moderate")
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);
            }
            else
            {
                 peak = new Peak(name, elevation, difficultyLevel);
                 peaks.Add(peak);
                 return string.Format(OutputMessages.PeakIsAllowed,name,difficultyLevel);   
            }
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = climbers.Get(climberName);
            IPeak peak= peaks.Get(peakName);
            if (climber == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }
            else if (peak==null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }
            else if (!baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName);
            }
            else if (peak.DifficultyLevel == "Extreme" && climber.GetType().Name == nameof(NaturalClimber))
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }
            else
            {
                bool isThrownException = false;
                IClimber demoClimber = climber;
                // demoClimber.Climb(peak);
                //
                // if (demoClimber.Stamina <= 0)
                // {
                //     isThrownException = true;
                //     
                // }
                var dificultylevel = peak.DifficultyLevel;
                int difLevel = 0;
                if (dificultylevel=="Extreme")
                {
                    difLevel = 6;
                }
                if (dificultylevel == "Hard")
                {
                    difLevel = 4;
                }
                else
                { difLevel = 2; }
                if (climber.Stamina <= difLevel)
                {
                    climber.
                    return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
                    
                }
                else
                {
                    climber.Climb(peak);
                    return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
                }
                
            }
            }

        public string BaseCampReport()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("BaseCamp residents:");

            if (baseCamp != null)
            {
                foreach (var climber in climbers.All)
                {
                    sb.AppendLine($"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
                }
            }
            else
            {
                sb.AppendLine("BaseCamp is currently empty.");
            }
            return sb.ToString().TrimEnd();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            string climberBase=baseCamp.Residents.FirstOrDefault(climberName);
            IClimber climber=climbers.Get(climberName);

            if (climber==null)
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }
            else if (climber.Stamina==10)
            {
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }
            else
            {
                climber.Rest(daysToRecover);
                return string.Format(OutputMessages.ClimberRecovered, climberName,daysToRecover);
            }
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber climber = climbers.Get(name);
            if (climber != null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated,name,nameof(ClimberRepository));
            }
            else
            {
                if (isOxygenUsed)
                {
                    climber = new OxygenClimber(name);
                }
                else
                {
                    climber=new NaturalClimber(name);
                }
                climbers.Add(climber);
                baseCamp.ArriveAtCamp(name);
                return string.Format(OutputMessages.ClimberArrivedAtBaseCamp,name);
            }
        }

        public string OverallStatistics()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            var sortedClimbers = climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count)
                                     .ThenBy(c => c.Name)
                                     .ToList();
            foreach (var climber in sortedClimbers)
            {
                sb.AppendLine($"{climber.ToString()}");
                var climberPeaks = climber.ConqueredPeaks;
                List<IPeak> peaksOrdered = new();
                foreach (var peak in climberPeaks)
                {
                    IPeak peakAttacked=peaks.Get(peak);
                    peaksOrdered.Add(peakAttacked);
                    
                }
                foreach (var peak in peaksOrdered.OrderBy(p=>p.Elevation))
                {
                    sb.AppendLine(peak.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
