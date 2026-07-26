namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           int enginesNumber=int.Parse(Console.ReadLine());
            List<Car>cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < enginesNumber; i++)
            {
                string[] inputArray = Console.ReadLine().Split();
                if (inputArray.Length==4)
                {
                    string model = inputArray[0];
                    int power = int.Parse(inputArray[1]);
                    int displacement = int.Parse(inputArray[2]);
                    string efficiency = inputArray[3];
                    Engine newEngine = new Engine(model, power, displacement, efficiency);
                    engines.Add(newEngine);
                }
                if (inputArray.Length==3)
                {
                    string model = inputArray[0];
                    int power =int.Parse(inputArray[1]);
                    string thirdParam = inputArray[2]; //displacement or efficiency
                    if (int.TryParse(thirdParam, out int displacement))
                    {
                        Engine newEngine = new Engine(model, power, displacement);
                        engines.Add(newEngine);
                    }

                    else
                    {
                        string efficiency = inputArray[2];
                        Engine newEngine = new Engine(model, power, efficiency);
                        engines.Add(newEngine);
                    }
                }
                if (inputArray.Length == 2)
                {
                    string model = inputArray[0];
                    int power = int.Parse(inputArray[1]);
                    Engine newEngine = new Engine(model, power);
                    engines.Add(newEngine);
                }

                
            }
            int numberCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCars; i++)
            {
                string[] inputArray = Console.ReadLine().Split();

                if (inputArray.Length == 4)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    int weight = int.Parse(inputArray[2]);
                    string color = inputArray[3];
                    if (engines.Any(e => e.Model == engineModel))
                    {
                        Engine findedEngine = engines.Where(e => e.Model == engineModel).First();
                        var newCar = new Car(model, findedEngine, weight, color);
                        cars.Add(newCar);
                    }
                }
                if (inputArray.Length == 3)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    string thirdParam = inputArray[2]; // weight or color
                    if (engines.Any(e => e.Model == engineModel))
                    {
                        Engine findedEngine = engines.Where(e => e.Model == engineModel).First();
                        if (int.TryParse(thirdParam, out int weight))
                        {
                            var newCar = new Car(model, findedEngine, weight);
                            cars.Add(newCar);
                        }

                        else
                        {
                            string color = inputArray[2];
                            var newCar = new Car(model, findedEngine, color);
                            cars.Add(newCar);
                        }
                    }
                }
                if (inputArray.Length == 2)
                {
                    string model = inputArray[0];
                    string engineModel = inputArray[1];
                    if (engines.Exists(e => e.Model == engineModel))
                    {
                        Engine findEngine = engines.Where(e => e.Model == engineModel).First();
                        Car newCar = new Car(model, findEngine);
                        cars.Add(newCar);
                    }
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}