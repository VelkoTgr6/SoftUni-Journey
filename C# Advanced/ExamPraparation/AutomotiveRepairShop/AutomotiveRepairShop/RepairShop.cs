using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        private int capacity;
        private List<Vehicle> vehicles;

        public int Capacity { get { return capacity; } set { capacity = value; } }
        public List<Vehicle> Vehicles { get {  return vehicles; } set {  vehicles = value; } }

        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            if (this.Vehicles.Count < this.Capacity)
            {
                this.Vehicles.Add(vehicle);
            }

        }
        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicleToRemove = Vehicles.FirstOrDefault(v => v.VIN == vin);

            if (vehicleToRemove != null)
            {
                // Remove the found vehicle
                Vehicles.Remove(vehicleToRemove);
                return true;
            }
            return false;

        }
        public int GetCount()
        {
            return Vehicles.Count;
        }
        public Vehicle GetLowestMileage()
        {
            Vehicle vehicleWithLowestMileage = Vehicles.OrderBy(vehicle => vehicle.Mileage).FirstOrDefault();

            return vehicleWithLowestMileage;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");

            foreach (Vehicle v in this.Vehicles)
            {
                sb.AppendLine(v.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
