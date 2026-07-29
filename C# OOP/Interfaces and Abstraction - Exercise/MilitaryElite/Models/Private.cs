using MilitaryElite.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string name, string lastName, decimal salary)
            : base(id, name, lastName)
        {
            Salary = salary;
        }

        public decimal Salary {  get; private set; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {Salary:f2}";
        }
    }
}
