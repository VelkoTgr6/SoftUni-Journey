using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        class Vehicle
        {
            public Vehicle(string type, string model, string color, decimal hP)
            {
                Type = type;
                Model = model;
                Color = color;
                HP = hP;
            }
            private string type = "";
            public string Type {
                get
                {
                    return type;
                }
                set
                {
                    type = Capitalize(value);
                }
            }
            public string Model { get; set; }
            
            public string Color { get; set; }
            public decimal HP { get; set; }
            
            public string Capitalize(string value)
            {
                char[] charArray = value.ToCharArray();
                if (char.IsLower(charArray[0]))
                {
                    charArray[0] = char.ToUpper(charArray[0]);
                }
                return new string (charArray);
            }
            public string Print()
            {
                string result = "";
                result += $"Type: {Type}\n";
                result += $"Model: {Model}\n";
                result += $"Color: {Color}\n";
                result += $"Horsepower: {HP}";
                return result;
            }
        }
        static void Main(string[] args)
        {
            string command;
            List<Vehicle> vehicles = new List<Vehicle>();
            while ((command=Console.ReadLine())!= "End")
            {
                string[] input = command.Split(" ");
                string type = input[0];
                string model = input[1];
                string color = input[2];
                decimal hp = decimal.Parse(input[3]);

                Vehicle vehicle = new Vehicle(type,model,color,hp);
                vehicles.Add(vehicle);

            }
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                Vehicle foundVehicle = vehicles.Find(vehicle => vehicle.Model == command);
                if (foundVehicle!=null)
                {
                    Console.WriteLine(foundVehicle.Print());
                }
            }

            decimal avarageHpCars = vehicles.Where(vehicle => vehicle.Type == "Car")
              .Select(vehicle => vehicle.HP)
              .DefaultIfEmpty()
              .Average();
                Console.WriteLine($"Cars have average horsepower of: {avarageHpCars:f2}.");


                decimal avarageHpTrucks = vehicles.Where(vehicle => vehicle.Type == "Truck")
                  .Select(vehicle => vehicle.HP)
                  .DefaultIfEmpty()
                  .Average();
                Console.WriteLine($"Trucks have average horsepower of: {avarageHpTrucks:f2}."); 
        }
    }
}
