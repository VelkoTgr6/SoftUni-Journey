using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models.Intefaces
{
    public interface ILieutenantGeneral:IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
