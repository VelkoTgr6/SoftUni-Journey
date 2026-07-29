using BorderControl.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Model
{
    internal class Rebel : IName,IBuyer
    {
        public Rebel(string name, int agency, string group)
        {
            Name = name;
            Agency = agency;
            Group = group;
        }

        public string Name { get; private set; }
        public int Agency { get; private set; }
        public string Group { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
