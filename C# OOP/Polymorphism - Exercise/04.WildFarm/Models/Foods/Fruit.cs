using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Foods
{
    public class Fruit : IFood
    {
        public Fruit(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
