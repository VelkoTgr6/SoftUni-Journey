using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer>players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            this.players =new PlayerRepository();
            this.teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new();
            sb.AppendLine("***League Standings***");

            foreach (var team in teams.Models.OrderByDescending(t=>t.PointsEarned)
                .ThenByDescending(t=>t.OverallRating)
                .ThenBy(t=>t.Name))
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            if(!players.ExistsModel(playerName))
            {
               return string.Format(OutputMessages.PlayerNotExisting, playerName,nameof(PlayerRepository));
            }
            if (!teams.ExistsModel(teamName))
            {
               return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }
            IPlayer player=players.GetModel(playerName);
            ITeam team=teams.GetModel(teamName);
            if (player.Team != default)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }
            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this.teams.GetModel(firstTeamName);
            var secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating>secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if(secondTeam.OverallRating > firstTeam.OverallRating) 
            {
                firstTeam.Lose();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }

        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(Goalkeeper) && typeName != nameof(CenterBack) && typeName != nameof(ForwardWing))  
            {
               return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
            if (players.ExistsModel(name))
            {
                string position=players.GetModel(name).GetType().Name;
                return string.Format(OutputMessages.PlayerIsAlreadyAdded,name,nameof(PlayerRepository),position);
            }

            IPlayer player;
            if (typeName == nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == nameof(CenterBack))
            {
                player = new CenterBack(name);
            }
            else
            {
                player = new ForwardWing(name);
            }

            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name,nameof(TeamRepository));
            }
            teams.AddModel(new Team(name));
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name,nameof(TeamRepository));
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new();
            sb.AppendLine($"***{teamName}***");
            ITeam team=teams.GetModel(teamName);

            foreach (var player in team.Players.OrderByDescending(p=>p.Rating).ThenBy(p=>p.Name))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
