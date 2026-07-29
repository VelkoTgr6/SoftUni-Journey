using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
        }

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel { get; private set; } = 100;

        public bool IsDamaged { get;private set; } = false;
        public void ChangeStatus()
        {
            if (IsDamaged == false)
            {
                IsDamaged= true;
            }
            else
            {
                IsDamaged = false;
            }
        }

        public void Drive(double mileage)
        {
            double percentageCovered = Math.Round((mileage/MaxMileage) * 100);
            
            BatteryLevel -= (int)percentageCovered;

            if (this.GetType().Name==nameof(CargoVan))
            {
                BatteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            BatteryLevel = 100;
        }
        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();

            sb.Append($"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: ");
            if (IsDamaged)
            {
                sb.AppendLine("damaged");
            }
            else
            {
                sb.AppendLine("OK");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
