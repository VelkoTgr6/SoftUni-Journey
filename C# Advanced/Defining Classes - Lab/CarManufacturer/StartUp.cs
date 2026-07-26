namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire> tires = new List<Tire>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireInfo = input.Split();
                for (int i = 0; i < tireInfo.Length; i+=2)
                {
                    int year = int.Parse(tireInfo[i]);
                    double pressure = double.Parse(tireInfo[i+1]);

                    tires.Add(new Tire(year, pressure));
                }

            }
            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split();
                for (int i = 0; i < engineInfo.Length; i += 2)
                {
                    int HP = int.Parse(engineInfo[i]);
                    double qubicCapacity = double.Parse(engineInfo[i+1]);
                    engines.Add(new Engine(HP, qubicCapacity));
                }
            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelConsumption = double.Parse(carInfo[4]);
                double fuelQuantity = double.Parse(carInfo[3])-(0.2 * fuelConsumption);
                
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);
                Car car = new Car
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    FuelQuantity = fuelQuantity,
                    FuelConsumption = fuelConsumption,
                    Engine = engines[engineIndex],
                    Tires = new Tire[] { tires[tiresIndex], tires[tiresIndex+1], tires[tiresIndex+2], tires[tiresIndex+3] }
                };
 
                
                cars.Add(car);
            }
            var specialCars=cars.Where(c=>c.Year>=2017 && c.Engine.HorsePower>330 && c.Tires.Sum(t=>t.Pressure)>=9  && c.Tires.Sum(tires=>tires.Pressure)<=10)
                .ToList();
            

           foreach (var specialCar in specialCars)
           {
               Console.WriteLine($"Make: {specialCar.Make}");
               Console.WriteLine($"Model: {specialCar.Model}");
               Console.WriteLine($"Year: {specialCar.Year}");
               Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
               Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
           }
        }
    }
}