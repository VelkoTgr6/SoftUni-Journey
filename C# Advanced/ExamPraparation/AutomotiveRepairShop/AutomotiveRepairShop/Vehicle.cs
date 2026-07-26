using System.Diagnostics;

namespace AutomotiveRepairShop
{
    public class Vehicle
    {
        private string vin;
        private int mileage;
        private string damage;

        public string VIN { get { return vin; } set { vin = value; } }
        public int Mileage { get { return mileage; } set { mileage = value; } }
        public string Damage { get { return damage; } set { damage = value; } }

        public Vehicle(string vin, int mileage, string damage)
        {
            this.VIN = vin;
            this.mileage = mileage;
            this.damage = damage;
        }
        public override string ToString()
        {
            return $"Damage: {damage}, Vehicle: {vin} ({mileage} km)";
        }

    }
}
