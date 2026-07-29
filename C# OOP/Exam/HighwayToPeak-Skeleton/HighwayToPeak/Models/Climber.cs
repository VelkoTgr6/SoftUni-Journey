using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private string name;
        public int stamina;
        private List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new List<string>();
        }

        public string Name
        {
            get { return name; }
            internal set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.ClimberNameNullOrWhiteSpace));
                }
                name = value;
            }
        }

        public int Stamina
        {
            get { return stamina; }
            protected set
            {
                stamina = Math.Max(0, Math.Min(10, value));
            }
        }

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks;

        public void Climb(IPeak peak)
        {
            if (ConqueredPeaks.Any(c=>c == peak.Name))
            {
                if (peak.DifficultyLevel == "Extreme")
                {
                    Stamina -= 6;
                }
                else if (peak.DifficultyLevel == "Hard")
                {
                    Stamina -= 4;
                }
                else
                {
                    Stamina -= 2;
                }
            }
            else
            {
                
                if (peak.DifficultyLevel == "Extreme")
                {
                    Stamina -= 6;
                }
                else if(peak.DifficultyLevel == "Hard")
                {
                    Stamina -= 4;
                }
                else
                {
                    Stamina -= 2;
                }
                  conqueredPeaks.Add(peak.Name);
                
            }
            
        }
        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.Append($"Peaks conquered: ");
            if (conqueredPeaks.Count==0)
            {
                sb.AppendLine("no peaks conquered");
            }
            else
            {
                sb.AppendLine($"{conqueredPeaks.Count}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
