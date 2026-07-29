using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.DelicacyTypes
{
    public class Gingerbread : Delicacy
    {
        private const double _price = 4.0;
        public Gingerbread(string name) : base(name, _price)
        {
        }
    }
}
