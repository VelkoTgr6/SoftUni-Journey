using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members=new List<Person>();

        public List<Person> Members { get { return members; } set { members = value; } }

        public void AddMember(Person person)
        {
            this.members.Add(person);
        }
        public Person GetOldestMember()
        {
            return Members.MaxBy(m => m.Age);
        }
       
    }
}
