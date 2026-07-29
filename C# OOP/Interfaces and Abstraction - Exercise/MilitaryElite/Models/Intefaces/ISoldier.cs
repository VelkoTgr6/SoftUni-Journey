using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Intefaces
{
    public interface ISoldier
    {
        int Id { get; }
        string Name { get; }
        string LastName { get; }

    }
}
