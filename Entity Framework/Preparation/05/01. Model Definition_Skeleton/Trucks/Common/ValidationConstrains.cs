

namespace Trucks.Common
{
    public class ValidationConstants
    {
        //Truck
        public const string TruckRegistrationNumberRegex = "^[A-Z]{2}\\d{4}[A-Z]{2}$";
        public const int TruckVinMaxLength = 17;
        public const int TruckTankCapacityMinValue = 950;
        public const int TruckTankCapacityMaxValue = 1420;
        public const int TruckCargoCapacityMinValue = 5000;
        public const int TruckCargoCapacityMaxValue = 29000;

        //Despatcher
        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;

        //Client
        public const int ClientNameMinLength = 2;
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;


    }
}
