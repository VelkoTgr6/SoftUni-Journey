using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models.Intercases
{
    public interface IResident
    {
        string Name { get; }
        string Counntry { get; }

        public string GetName(string name);
    }
}
