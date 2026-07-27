using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Truck> trucks = new List<Truck>();
            List<Car> cars = new List<Car>();
            while ((input=Console.ReadLine())!="end")
            {
                string[] tokens = input.Split('/').ToArray();
                string vehicleType = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                double horsePowerOrWeight =double.Parse(tokens[3]);
                if (vehicleType == "Truck")
                {
                    Truck truck = new Truck(brand, model, horsePowerOrWeight);
                    trucks.Add(truck);
                }
                else
                {
                    Car car = new Car(brand, model, horsePowerOrWeight);
                    cars.Add(car);
                }
            }
            if (cars.Count>0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in cars.OrderBy(x => x.Brand))
                {
                    //Console.WriteLine("Cars:");
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in trucks.OrderBy(x => x.Brand))
                {
                    // Console.WriteLine("Trucks:");
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
            
        }
    }
    class Truck
    {
        public Truck(string brand, string model, double weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }
    class Car
    {
        public Car(string brand, string model, double horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }
  //   class CatalogueVehicle
  // {
  //     public CatalogueVehicle(List<Truck> trucks, List<Car> cars)
  //     {
  //         this.trucks = trucks;
  //         this.cars = cars;
  //     }
  //
  //     public List<Truck> trucks {get;set;}
  //     public Li  st<Car> cars { get; set; }
  // }
}
