using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IRoute> routes;
        private IRepository<IVehicle> vehicles;

        public Controller()
        {
            this.users = new UserRepository();
            this.routes = new RouteRepository();
            this.vehicles = new VehicleRepository();
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            int roadId = routes.GetAll().Count() + 1;
            IRoute existingRoute = routes.GetAll()
                .FirstOrDefault(s=>s.StartPoint==startPoint && s.EndPoint==endPoint);

            if (existingRoute!=null)
            {
                if (existingRoute.Length==length)
                {
                    return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
                }
                else if (existingRoute.Length < length)
                {
                    return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
                }
                else if(existingRoute.Length > length)
                {
                    existingRoute.LockRoute();
                }
            }
            IRoute route=new Route(startPoint, endPoint, length,roadId);
            routes.AddModel(route);
            
            return string.Format(OutputMessages.NewRouteAdded,startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = users.FindById(drivingLicenseNumber);
            var vehicle=vehicles.FindById(licensePlateNumber);
            var route = routes.FindById(routeId);   

            if (user.IsBlocked)
            {
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            if (vehicle.IsDamaged)
            {
                return string.Format(OutputMessages.VehicleDamaged, drivingLicenseNumber);
            }
            if(route.IsLocked)
            {
                return string.Format(OutputMessages.RouteLocked, routeId);
            }
            vehicle.Drive(route.Length);
            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }
            return vehicle.ToString();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser user=users.FindById(drivingLicenseNumber);
            if (user!=null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded,drivingLicenseNumber);
            }
            user=new User(firstName, lastName,drivingLicenseNumber);
            users.AddModel(user);
            return string.Format(OutputMessages.UserSuccessfullyAdded,firstName, lastName, drivingLicenseNumber);
            
        }

        public string RepairVehicles(int count)
        {
            int countVehicles = 0;
            var damagedVehicles = vehicles.GetAll().Where(v => v.IsDamaged).OrderBy(b=>b.Brand).ThenBy(m=>m.Model);

            if (count < damagedVehicles.Count())
            {
                countVehicles = count;
            }
            else
            {
                countVehicles = damagedVehicles.Count();
            }

            var selectedVehicles=damagedVehicles.ToArray().Take(countVehicles);

            foreach (var vehicle in selectedVehicles)
            {   
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            
            return string.Format(OutputMessages.RepairedVehicles, countVehicles);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != nameof(CargoVan) && vehicleType != nameof(PassengerCar))
            {
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle!=null)
            {
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            else
            {
                if (vehicleType==nameof(PassengerCar))
                {
                    vehicle=new PassengerCar(brand,model,licensePlateNumber);
                }
                if (vehicleType==nameof(CargoVan))
                {
                    vehicle = new CargoVan(brand, model, licensePlateNumber);
                }
                vehicles.AddModel(vehicle);
                return string.Format(OutputMessages.VehicleAddedSuccessfully,brand,model,licensePlateNumber);
            }

        }

        public string UsersReport()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (var user in users.GetAll().OrderByDescending(r=>r.Rating).ThenBy(l=>l.LastName).ThenBy(f=>f.FirstName))
            {
                sb.AppendLine(user.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
