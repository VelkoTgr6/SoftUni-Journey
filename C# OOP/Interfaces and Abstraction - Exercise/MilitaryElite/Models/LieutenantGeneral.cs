using MilitaryElite.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string name, string lastName, decimal salary,IReadOnlyCollection<IPrivate> privates)
            : base(id, name, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var curentPriv in Privates)
            {
                sb.AppendLine($"  {curentPriv.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
