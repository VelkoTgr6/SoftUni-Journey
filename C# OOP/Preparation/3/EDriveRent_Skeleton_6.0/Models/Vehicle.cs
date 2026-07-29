using EDriveRent.Models.Contracts;
using EDriveRent.Models.VehicleTypes;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EDriveRent.Models
{
    public class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlate;

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
                    throw new ArgumentException(ExceptionMessages.BrandNull);
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
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage {get;private set;}

        public string LicensePlateNumber
        {
            get { return licensePlate; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlate = value;
            }
        }

        public int BatteryLevel { get; private set; } = 100;

        public bool IsDamaged {get; private set; }=false;

        public void ChangeStatus()
        {
            if(IsDamaged)
            {
                IsDamaged = false;
            }
            else
            {
                IsDamaged = true;
            }
        }

        public void Drive(double mileage)
        {
            BatteryLevel /= (int)Math.Round(MaxMileage/mileage);
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
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: ");

            if (IsDamaged)
            {
                stringBuilder.AppendLine("damaged");
            }
            if(IsDamaged==false)
            {
                stringBuilder.AppendLine("OK"); 
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
