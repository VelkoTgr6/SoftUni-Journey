using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BorderControl;
using BorderControl.Model.Interface;

namespace BorderControl
{
    public class Citizen : IIdentifiable,IName,IBirthDate,IBuyer
    {
        public Citizen(string name, int age,string id, string birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; } 
        public string Id { get; private set; }
        public string BirthDate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
