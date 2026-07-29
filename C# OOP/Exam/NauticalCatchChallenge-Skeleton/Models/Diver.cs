using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> coughtFish;
        private double competitionPoints = 0;

        public Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            coughtFish = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set
            {
                if (value<0)
                {
                    value = 0;
                }
                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch => coughtFish;

        public double CompetitionPoints
        {
            get { return Math.Round(competitionPoints, 1); }
            private set { competitionPoints = value; }
        }

        public bool HasHealthIssues { get;private set; }=false;

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            coughtFish.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);
        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            HasHealthIssues = true;
        }
        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
