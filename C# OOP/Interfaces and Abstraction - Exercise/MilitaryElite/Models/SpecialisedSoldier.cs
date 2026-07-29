using MilitaryElite.Enums;
using MilitaryElite.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string name, string lastName, decimal salary,Corps corps)
            : base(id, name, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps {  get; private set; }

        public override string ToString()
        {
            return base.ToString()+$"{Environment.NewLine}Corps: {Corps}";
        }
    }
}
