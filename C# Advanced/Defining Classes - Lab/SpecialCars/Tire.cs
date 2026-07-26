using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SpecialCars
{
    public class Tire
    {
        
        public Tire(int year1, double pressure1, int year2, double pressure2, int year3, double pressure3, int year4, double pressure4)
        {
            Year1 = year1;
            Pressure1 = pressure1;
            Year2 = year2;
            Pressure2 = pressure3;
            Year3 = year3;
            Pressure3 = pressure3;
            Year4 = year4;
            Pressure4 = pressure4;
        }
        public int Year1 { get; set; }
        public int Year2 { get; set; }
        public double Pressure1 { get; set; }
        public double Pressure2 { get; set; }
        public int Year3 { get; set; }
        public int Year4 { get; set; }
        public double Pressure3 { get; set; }
        public double Pressure4 { get; set; }
    }
}
