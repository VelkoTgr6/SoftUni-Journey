using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;
        private IReadOnlyCollection<IVehicle> collection;

        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
            this.collection = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier);
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return collection = vehicles.AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
            var user = vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier);
            return vehicles.Remove(user);
        }
    }
}
