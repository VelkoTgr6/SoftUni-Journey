using ExplicitInterfaces.Models.Intercases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string counntry, int age)
        {
            Name = name;
            Counntry = counntry;
            Age = age;
        }

        public string Name { get; private set; }

        public string Counntry { get; private set; }

        public int Age { get; private set; }
        public string GetName(string name)
        {
            return $"Mr/Ms/Mrs {name}";
        }
    }
}
