using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialCars
{
    public class Car
    {
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine,Tire tire)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            Engine = engine;
            Tire = tire;
        }
        public void Drive()
        { 
                this.FuelQuantity -= 20 * this.FuelConsumption*0.01;

                StringBuilder sb = new StringBuilder();
                Console.WriteLine(($"Make: {this.Make}"));
                Console.WriteLine(($"Model: {this.Model}"));
                Console.WriteLine(($"Year: {this.Year}"));
                Console.WriteLine(($"HorsePowers: {this.Engine.HorsePower}"));
                Console.WriteLine(($"FuelQuantity: {this.FuelQuantity:f1}"));
               
            
        }

        public string Make {  get; set; }
        public string Model { get; set; }

        public int Year { get; set; }
        public  double FuelQuantity {  get; set; }
        public double FuelConsumption {  get; set; }
        public Engine Engine {  get; set; }
        public Tire Tire {  get; set; }
    }
}
