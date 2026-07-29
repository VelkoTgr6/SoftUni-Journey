using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.DelicacyTypes
{
    public class Stolen : Delicacy
    {
        private const double _price = 3.50;
        public Stolen(string name) : base(name, _price)
        {
        }
    }
}
