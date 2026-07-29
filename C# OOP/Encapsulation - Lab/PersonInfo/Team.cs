using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    internal class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public IReadOnlyCollection<Person> FirstTeam=> firstTeam.AsReadOnly();

        public IReadOnlyCollection<Person>ReserveTeam=> reserveTeam.AsReadOnly();
        
        public Team(string name)
        {
            name = Name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }
        
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }

        }

        public string Name { get { return name; } }

    }
}
