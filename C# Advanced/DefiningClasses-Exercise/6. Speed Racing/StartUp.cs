using System;
using SpeedRacing;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();   
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car car = new Car();
                car.Model = input[0];
                car.FuelAmount = double.Parse(input[1]);
                car.FuelConsumptionPerKilometer = double.Parse(input[2]);
                cars.Add(car);
            }
            
            string command;
            while ((command=Console.ReadLine())!= "End")
            {
                string[] input =command.Split();
                Car car = cars.FirstOrDefault(c => c.Model == input[1]);
                car.CanMove(double.Parse(input[2]));
                
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}