using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private string team;
        private double rating;

        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        public double Rating { get => rating; protected set => rating = value; }

        public string Team { get => team; protected set => team = value; }

        public abstract void DecreaseRating();
        public abstract void IncreaseRating();
        public void JoinTeam(string name)
        {
            Team = name;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {this.Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
