using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.DiverTypes;
using NauticalCatchChallenge.Models.FishTypes;
using System.IO;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fishes;

        public Controller()
        {
            this.divers = new DiverRepository();
            this.fishes = new FishRepository();
        }


        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, this.GetType().Name, diverName);
            }
            if (fishes.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }
            if (divers.GetModel(diverName).HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }
            if (divers.GetModel(diverName).OxygenLevel < fishes.GetModel(fishName).TimeToCatch)
            {
                divers.GetModel(diverName).Miss(fishes.GetModel(fishName).TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (divers.GetModel(diverName).OxygenLevel > fishes.GetModel(fishName).TimeToCatch)
            {
                divers.GetModel(diverName).Hit(fishes.GetModel(fishName));
                if (divers.GetModel(diverName).OxygenLevel <= 0)
                {
                    divers.GetModel(diverName).HasHealthIssues = true;
                }
                return string.Format(OutputMessages.DiverHitsFish, diverName, fishes.GetModel(fishName).Points, fishName);
            }
            else
            {
                if (isLucky == true)
                {
                    divers.GetModel(diverName).Hit(fishes.GetModel(fishName));
                    if (divers.GetModel(diverName).OxygenLevel <= 0)
                    {
                        divers.GetModel(diverName).HasHealthIssues = true;
                    }
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fishes.GetModel(fishName).Points, fishName);

                }
                divers.GetModel(diverName).Miss(fishes.GetModel(fishName).TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var diver in divers.Models.OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count).OrderBy(n => n.Name))
            {
                if (diver.HasHealthIssues)
                {
                    sb.AppendLine(diver.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            Type type = Type.GetType(diverType);

            if (type == null || !typeof(IDiver).IsAssignableFrom(type))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
            if (divers.GetModel(diverName) != null)
            {
                throw new ArgumentException(OutputMessages.DiverNameDuplication, this.GetType().Name);
            }
            IDiver newDiver = null;
            switch (diverType)
            {
                case "FreeDiver":
                    newDiver = new FreeDiver(diverName);
                    break;
                case "ScubaDiver":
                    newDiver = new ScubaDiver(diverName);
                    break;
            }
            divers.AddModel(newDiver);
            return string.Format(OutputMessages.DiverRegistered, diverName, this.GetType().Name);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new StringBuilder();
            var diver = divers.GetModel(diverName);
            sb.AppendLine(diver.ToString());
            foreach (var fish in diver.Catch)
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        
        public string HealthRecovery()
        {
            foreach (var diver in divers.Models)
            {
                if (diver is Diver diverImpl)
                {
                    diverImpl.HasHealthIssues = false;
                }
            }
            int counter = 0;
            foreach (var diver in divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    diver.HasHealthIssues = false;
                    diver.RenewOxy();
                    counter++;

                }


            }
            return string.Format(OutputMessages.DiversRecovered, counter);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            Type type = Type.GetType(fishType);

            if (type == null || !typeof(IFish).IsAssignableFrom(type))
            {
                throw new ArgumentException(OutputMessages.FishTypeNotPresented, fishType);
            }
            if (fishes.GetModel(fishName) != null)
            {
                throw new ArgumentException(OutputMessages.FishNameDuplication, this.GetType().Name);
            }

            IFish fish = null;
            if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            this.fishes.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }
        foreach (var diver in divers.Models)
{
    if (diver is Diver diverImpl)
    {
        diverImpl.HasHealthIssues = false;
    }
}
