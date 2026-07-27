using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team(string name, string creator)
        {
            Creator = creator;
            Name = name;
            Members = new List<string>();
            Members.Sort();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split("-").ToArray();
                string creator = command[0];
                string teamName = command[1];
               
               
                Team sameCreator = teams.Find(team => team.Creator == creator);
                if (sameCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team sameTeam = teams.Find(team => team.Name == teamName);
                if (sameTeam!= null)
                {
                    Console.WriteLine($"Team {sameTeam.Name} was already created!");
                    continue;
                }

                Team team = new Team(teamName,creator);
                teams.Add(team);
                    Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
            }

            string input;
            while ((input=Console.ReadLine())!= "end of assignment")
            {
                string[] command = input.Split("->");
                string memberName = command[0];
                string teamName = command[1];

                Team existCreator = teams.Find(team => team.Creator==memberName);
                Team existMember = teams.Find(team => team.Members.Contains(memberName));
                if (existMember != null || existCreator != null||teams.Any(t=>t.Creator==memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                Team foundTeam = teams.Find(team => team.Name == teamName);
                if (foundTeam != null)
                {
                    foundTeam.Members.Add(memberName);
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

            }

            List<Team> validTeams = teams.FindAll(teams => teams.Members.Count > 0);
            List<Team> disbandedTeams = teams.FindAll(teams => teams.Members.Count == 0);

            validTeams = validTeams.OrderByDescending(team => team.Members.Count)
                .ThenBy(team=>team.Name)
                .ToList();
            disbandedTeams = disbandedTeams.OrderBy(team => team.Name).ToList();

            foreach (Team team in validTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach (string members in team.Members)
                {
                    Console.WriteLine($"-- {members}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team team in disbandedTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
